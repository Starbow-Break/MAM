using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsharpMiniGameController : MonoBehaviour
{
    [SerializeField] NoteSpawner _noteSpawner;

    private Queue<EventQueueData> eventQueue = new(); // 이벤트 큐
    private Queue<JudgeQueueData> judgeQueue = new(); // 판정 큐
    
    private float playTime = 0.0f;
    
    private void SetChartData(ChartData chartData)
    {
        ChartQueueData chartQueueData = ChartQueueDataGenerator.Generate(chartData);
        foreach (var eventQueueData in chartQueueData.EventQueueDatas)
        {
            eventQueue.Enqueue(eventQueueData);
        }
        foreach (var judgeQueueData in chartQueueData.JudgeQueueDatas)
        {
            judgeQueue.Enqueue(judgeQueueData);
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
        while (eventQueue.Count > 0 || judgeQueue.Count > 0)
        {
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
        CsharpMiniGame.Instance.VisualizeCountSetter.SetCount(count);
    }
    
    private void ShowForNodeGuide()
    {
        Debug.Log("For");
    }
    #endregion
}
