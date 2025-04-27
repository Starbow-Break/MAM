using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CSharpMiniGameController : MonoBehaviour
{
    [SerializeField] NoteSpawner _noteSpawner;
    [SerializeField] TextMeshProUGUI _testText;
    
    private float startTime;

    public UnityAction<JudgeInfo> OnJudge;

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
        SetChartData(chartData);
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        yield return PlayChartSequence();
    }
    
    private IEnumerator PlayChartSequence()
    {
        startTime = Time.time;
        
        var eventQueue = CSharpMiniGameQueue.EventQueue;
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        
        while (eventQueue.Count > 0 || judgeQueue.Count > 0)
        {
            ResolveMiss();
            
            float playTime = Time.time - startTime;
            
            playTime += Time.deltaTime;
            if (eventQueue.Count > 0 && eventQueue.Peek().Time <= playTime)
            {
                var eventQueueData = eventQueue.Dequeue();
                if (eventQueueData.EventType == EEventType.Visualize)
                {
                    ShowNoteGuide(eventQueueData);
                }
                else
                {
                    _noteSpawner.SpawnNote(eventQueueData);
                }
            }
            
            yield return null;
        }
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

    private void ResolveMiss()
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
            var judgeQueueData = judgeQueue.Dequeue();
            var currentNote = noteQueue.Dequeue();
            SpriteRenderer noteRenderer = currentNote.GetComponentInChildren<SpriteRenderer>();
            JudgeInfo judgeInfo = new JudgeInfo(
                judge,
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
            var judgeQueueData = judgeQueue.Dequeue();
            var currentNote = noteQueue.Dequeue();
            SpriteRenderer noteRenderer = currentNote.GetComponentInChildren<SpriteRenderer>();
            JudgeInfo judgeInfo = new JudgeInfo(
                judge,
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
