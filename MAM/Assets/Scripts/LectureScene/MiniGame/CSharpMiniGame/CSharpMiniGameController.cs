using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CSharpMiniGameController : MonoBehaviour
{
    [SerializeField] NoteSpawner _noteSpawner;
    [SerializeField] private AudioSource _music;
    
    private float startTime;
    private float currentScoreWeight;
    private float maxScoreWeight;

    public UnityAction<JudgeInfo> OnJudge;
    public UnityAction OnPlayChartEnded;

    private void OnEnable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => OnHit();
    }

    private void OnDisable()
    {
        CSharpMiniGame.Input.OnKeyDown -= () => OnHit();
    }
    
    private void SetChartData(ChartData chartData)
    {
        maxScoreWeight = CSharpMiniGameScoreHelper.GetTotalMaxWeight(chartData);
        
        CSharpMiniGameQueue.ClearAllQueues();
        ChartQueueData chartQueueData = ChartQueueDataGenerator.Generate(chartData);
        foreach (var eventQueueData in chartQueueData.EventQueueDatas)
        {
            CSharpMiniGameQueue.EventQueue.Enqueue(eventQueueData);
        }
        foreach (var judgeQueueData in chartQueueData.JudgeQueueDatas)
        {
            CSharpMiniGameQueue.JudgeQueue.Enqueue(judgeQueueData);
        }
    }
    
    #region Play Chart
    public void Play(ChartData chartData)
    {
        currentScoreWeight = 0f;
        SetChartData(chartData);
        StartCoroutine(PlaySequence(chartData.MusicClip, chartData.Delay, chartData.Offset));
    }

    private IEnumerator PlaySequence(AudioClip musicClip, float delay, float chartOffset)
    {
        yield return MusicLoaded(musicClip);
        StartCoroutine(PlayMusicSequence(musicClip, delay));
        yield return PlayChartSequence(delay);
    }

    private IEnumerator MusicLoaded(AudioClip musicClip)
    {
        _music.clip = musicClip;
        musicClip.LoadAudioData();
        yield return new WaitUntil(() => musicClip.loadState == AudioDataLoadState.Loaded);
    }

    private IEnumerator PlayMusicSequence(AudioClip musicClip, float delay)
    {
        yield return new WaitForSeconds(delay);
        _music.PlayOneShot(musicClip);
    }
    
    private IEnumerator PlayChartSequence(float delay)
    {
        Debug.Log(Time.time);
        startTime = Time.time + delay;
        
        var eventQueue = CSharpMiniGameQueue.EventQueue;
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        
        while (eventQueue.Count > 0 || judgeQueue.Count > 0 || _music.isPlaying)
        {
            ResolveNoHit();
            
            float playTime = Time.time - startTime;
            
            playTime += Time.deltaTime;
            while (eventQueue.Count > 0 && eventQueue.Peek().Time <= playTime)
            {
                var eventQueueData = eventQueue.Dequeue();
                if (eventQueueData.EventType == EEventType.Visualize)
                {
                    ShowNoteGuide(eventQueueData);
                }
                else
                {
                    Debug.Log(eventQueueData.NoteType);
                    _noteSpawner.SpawnNote(eventQueueData);
                }
            }
            
            yield return null;
        }
        
        OnPlayChartEnded?.Invoke();
    }

    private void ShowNoteGuide(EventQueueData data)
    {
        if (data.NoteType == ENoteType.If)
        {
            ShowIfNoteGuide(data);
        }
        else if (data.NoteType == ENoteType.For)
        {
            ShowForNoteGuide(data);
        }
    }

    private void ShowIfNoteGuide(EventQueueData data)
    {
        CSharpMiniGame.VisualizeCountSetter.SetCount(data.Count);
        CSharpMiniGame.JudgeLineSetter.SetColor(data.Color);
        CSharpMiniGame.SpeechBubbleSetter.Show($"If {data.Count}", data.LifeTime);
    }

    private void ShowForNoteGuide(EventQueueData data)
    {
        CSharpMiniGame.SpeechBubbleSetter.Show($"For {data.Count}", data.LifeTime);
    }
    #endregion
    
    #region Judge
    private EJudge CalculateCurrentJudge() {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;

        float playTime = Time.time - startTime;
        var judgeData = judgeQueue.Peek();
        float delta = playTime - judgeData.Time;
        bool isHit = judgeData.isHit;

        EJudge judge = CSharpMiniGameJudgeHelper.Judge(delta, isHit);
        
        return judge;
    }

    private void ResolveNoHit()
    {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        var noteQueue = CSharpMiniGameQueue.NoteQueue;

        if (judgeQueue.Count <= 0 || noteQueue.Count <= 0)
        {
            return;
        }

        bool isHit = judgeQueue.Peek().isHit;
        EJudge judge = CalculateCurrentJudge();

        if ((isHit && judge == EJudge.Miss) || (!isHit && judge == EJudge.Perfect))
        {
            currentScoreWeight += CSharpMiniGameScoreHelper.GetJudgeScoreWeight(judge);
            float score = Mathf.Floor(currentScoreWeight / maxScoreWeight * 10000f) / 100f;
            LectureSceneManager.MiniGameController.UIUpdater.SetScore(score);
            
            var judgeQueueData = judgeQueue.Dequeue();
            var currentNote = noteQueue.Dequeue();
            SpriteRenderer noteRenderer = currentNote.GetComponentInChildren<SpriteRenderer>();
            JudgeInfo judgeInfo = new JudgeInfo(
                judge,
                judgeQueueData.Type,
                judgeQueueData.isHit,
                noteRenderer.sprite,
                new Color(noteRenderer.color.r, noteRenderer.color.g, noteRenderer.color.b, 1f),
                currentNote.ModelTransform.rotation,
                currentNote.ModelTransform.localScale
            );
            NotePoolManager.Instance.ReleaseNote(judgeQueueData.Type, currentNote);

            Debug.Log($"{judge}");
            
            OnJudge?.Invoke(judgeInfo);
        } 
    }
    
    private void OnHit()
    {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        var noteQueue = CSharpMiniGameQueue.NoteQueue;

        if (judgeQueue.Count <= 0 || noteQueue.Count <= 0)
        {
            return;
        }

        EJudge judge = CalculateCurrentJudge();

        if (judge != EJudge.None)
        {
            currentScoreWeight += CSharpMiniGameScoreHelper.GetJudgeScoreWeight(judge);
            float score = Mathf.Floor(currentScoreWeight / maxScoreWeight * 10000f) / 100f;
            LectureSceneManager.MiniGameController.UIUpdater.SetScore(score);
            
            var judgeQueueData = judgeQueue.Dequeue();
            var currentNote = noteQueue.Dequeue();
            SpriteRenderer noteRenderer = currentNote.GetComponentInChildren<SpriteRenderer>();
            JudgeInfo judgeInfo = new JudgeInfo(
                judge,
                judgeQueueData.Type,
                judgeQueueData.isHit,
                noteRenderer.sprite,
                new Color(noteRenderer.color.r, noteRenderer.color.g, noteRenderer.color.b, 1f),
                currentNote.ModelTransform.rotation,
                currentNote.ModelTransform.localScale
            );
            NotePoolManager.Instance.ReleaseNote(judgeQueueData.Type, currentNote);

            Debug.Log($"{(Time.time - startTime - judgeQueueData.Time) * 1000f}ms {judge}");

            OnJudge?.Invoke(judgeInfo);
        }
    }
    #endregion
}