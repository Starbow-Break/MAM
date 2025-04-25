using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CSharpMiniGameController : MonoBehaviour
{
    [SerializeField] NoteSpawner _noteSpawner;
    [SerializeField] TextMeshProUGUI _testText;
    
    private float startTime;

    public UnityAction<ENoteType, EJudge> OnJudge;

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
                    if (eventQueueData.NoteType == ENoteType.If)
                    {
                        ShowIfNodeGuide(eventQueueData.Count);
                    }
                }
                else
                {
                    _noteSpawner.SpawnNote(eventQueueData);
                }
            }
            
            yield return null;
        }
    }

    private void ShowIfNodeGuide(int count)
    {
        Debug.Log("If");
        CSharpMiniGame.VisualizeCountSetter.SetCount(count);
    }
    
    private void ShowForNodeGuide()
    {
        Debug.Log("For");
    }
    #endregion
    
    #region Judge

    private void ResolveMiss()
    {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        var noteQueue = CSharpMiniGameQueue.NoteQueue;
        if (judgeQueue.Count <= 0)
        {
            return;
        }
        
        float playTime = Time.time - startTime;
        var judgeData = judgeQueue.Peek();
        float delta = playTime - judgeData.Time;
        EJudge judge = CSharpMiniGameJudgeHelper.Judge(delta);

        if (judge == EJudge.Miss)
        {
            Debug.Log($"{delta} {judge}");
            judgeQueue.Dequeue();
            GameObject currentNote = noteQueue.Dequeue();
            Destroy(currentNote);
            
            OnJudge?.Invoke(judgeData.Type, judge);
        } 
    }
    
    private void OnHit()
    {
        var judgeQueue = CSharpMiniGameQueue.JudgeQueue;
        var noteQueue = CSharpMiniGameQueue.NoteQueue;
        if (judgeQueue.Count <= 0)
        {
            return;
        }
        
        float playTime = Time.time - startTime;
        var judgeData = judgeQueue.Peek();
        float delta =  playTime - judgeData.Time;
        EJudge judge = CSharpMiniGameJudgeHelper.Judge(delta);

        if (judge != EJudge.None)
        {
            Debug.Log($"{delta} {judge}");
            _testText.text = $"{Mathf.RoundToInt(delta * 1000f)}ms";
            judgeQueue.Dequeue();
            GameObject currentNote = noteQueue.Dequeue();
            Destroy(currentNote);
            OnJudge?.Invoke(judgeData.Type, judge);
        }
    }
    #endregion
}
