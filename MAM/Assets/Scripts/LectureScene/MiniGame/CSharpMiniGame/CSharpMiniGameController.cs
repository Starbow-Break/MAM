using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CSharpMiniGameController : MonoBehaviour
{
    [SerializeField] private NoteSpawner _noteSpawner;
    [SerializeField] private AudioSource _music;
    [SerializeField] private CSharpMiniGameSFXAudio _sfxAudio;
    private float currentScoreWeight;
    private float maxScoreWeight;

    public UnityAction<JudgeInfo> OnJudge;
    public UnityAction OnPlayChartEnded;

    private float startTime;

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
        var chartQueueData = ChartQueueDataGenerator.Generate(chartData);
        foreach (var eventQueueData in chartQueueData.EventQueueDatas)
            CSharpMiniGameQueue.EventQueue.Enqueue(eventQueueData);
        foreach (var judgeQueueData in chartQueueData.JudgeQueueDatas)
            CSharpMiniGameQueue.JudgeQueue.Enqueue(judgeQueueData);
        foreach (var soundQueueData in chartQueueData.SoundQueueDatas)
            CSharpMiniGameQueue.SoundQueue.Enqueue(soundQueueData);
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
        startTime = Time.time + delay;

        var eventQueue = CSharpMiniGameQueue.EventQueue;
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        var soundQueue = CSharpMiniGameQueue.SoundQueue;

        while (
            eventQueue.Count > 0 || judgeQueue.Count > 0
                                 || soundQueue.Count > 0 || _music.isPlaying)
        {
            var playTime = Time.time - startTime;

            while (soundQueue.Count > 0 && soundQueue.Peek().Time <= playTime)
            {
                var soundQueueData = soundQueue.Dequeue();
                Debug.Log(soundQueueData.SoundType);
                _sfxAudio.PlaySFX(soundQueueData.SoundType);
            }

            ResolveNoHit();

            while (eventQueue.Count > 0 && eventQueue.Peek().Time <= playTime)
            {
                var eventQueueData = eventQueue.Dequeue();
                if (eventQueueData.EventType == EEventType.Visualize)
                    ShowNoteGuide(eventQueueData);
                else
                    _noteSpawner.SpawnNote(eventQueueData);
            }

            yield return null;
        }

        OnPlayChartEnded?.Invoke();
    }

    private void ShowNoteGuide(EventQueueData data)
    {
        if (data.NoteType == ENoteType.If)
            ShowIfNoteGuide(data);
        else if (data.NoteType == ENoteType.For) ShowForNoteGuide(data);
    }

    private void ShowIfNoteGuide(EventQueueData data)
    {
        CSharpMiniGame.VisualizeCountSetter.SetCount(data.Count);
        CSharpMiniGame.JudgeLineSetter.SetColor(data.Color);
        CSharpMiniGame.SpeechBubbleSetter.Show(data);
    }

    private void ShowForNoteGuide(EventQueueData data)
    {
        CSharpMiniGame.SpeechBubbleSetter.Show(data);
    }

    #endregion

    #region Judge

    private EJudge CalculateCurrentJudge()
    {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;

        var playTime = Time.time - startTime;
        var judgeData = judgeQueue.Peek();
        var delta = playTime - judgeData.Time;
        var isHit = judgeData.isHit;

        var judge = CSharpMiniGameJudgeHelper.Judge(delta, isHit);

        return judge;
    }

    private void ResolveNoHit()
    {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        var noteQueue = CSharpMiniGameQueue.NoteQueue;

        if (judgeQueue.Count <= 0 || noteQueue.Count <= 0) return;

        var isHit = judgeQueue.Peek().isHit;
        var judge = CalculateCurrentJudge();

        if ((isHit && judge == EJudge.Miss) || (!isHit && judge == EJudge.Perfect))
        {
            currentScoreWeight += CSharpMiniGameScoreHelper.GetJudgeScoreWeight(judge);
            var score = Mathf.Floor(currentScoreWeight / maxScoreWeight * 10000f) / 100f;
            CSharpMiniGame.Instance.Score = score;
            LectureSceneManager.MiniGameController.UIUpdater.SetScore(score);

            var judgeQueueData = judgeQueue.Dequeue();
            var currentNote = noteQueue.Dequeue();
            var noteRenderer = currentNote.GetComponentInChildren<SpriteRenderer>();
            var judgeInfo = new JudgeInfo(
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

        if (judgeQueue.Count <= 0 || noteQueue.Count <= 0) return;

        var judge = CalculateCurrentJudge();

        if (judge != EJudge.None)
        {
            currentScoreWeight += CSharpMiniGameScoreHelper.GetJudgeScoreWeight(judge);
            var score = Mathf.Floor(currentScoreWeight / maxScoreWeight * 10000f) / 100f;
            CSharpMiniGame.Instance.Score = score;
            LectureSceneManager.MiniGameController.UIUpdater.SetScore(score);

            var judgeQueueData = judgeQueue.Dequeue();
            var currentNote = noteQueue.Dequeue();
            var noteRenderer = currentNote.GetComponentInChildren<SpriteRenderer>();
            var judgeInfo = new JudgeInfo(
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