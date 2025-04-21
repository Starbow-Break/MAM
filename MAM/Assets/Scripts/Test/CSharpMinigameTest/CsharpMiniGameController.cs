using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CsharpMiniGameController : MonoBehaviour
{
    private float _bpm;  // BPM
    private float _offset;   // 오프셋

    private Queue<NoteData> noteQueue = new();

    private int beat = 0;
    private float realTime = 0.0f;
    
    public void Play(ChartData chartData)
    {
        SetChartData(chartData);
        StartCoroutine(PlaySequence());
    }

    private void SetChartData(ChartData chartData)
    {
        _bpm = chartData.bpm;
        _offset = chartData.offset;
        
        noteQueue.Clear();
        foreach (NoteData note in chartData.notes)
        {
            noteQueue.Enqueue(note);
        }
    }

    private IEnumerator PlaySequence()
    {
        float offsetMiliSeconds = _offset * 0.001f;
        float audioDelay = Mathf.Max(0f, -offsetMiliSeconds);
        float chartDelay = Mathf.Max(0f, offsetMiliSeconds);
        
        StartCoroutine(PlayAudioSequence(audioDelay));
        yield return PlayChartSequence(chartDelay);
    }

    private IEnumerator PlayAudioSequence(float delay)
    {
        var wait = delay > 0 ? new WaitForSeconds(delay) : null;
        yield return wait;
        // 오디오 재생
    }
    
    private IEnumerator PlayChartSequence(float delay)
    {
        var wait = delay > 0 ? new WaitForSeconds(delay) : null;
        if (wait != null)
        {
            yield return wait;
        }

        float t = Time.time;

        while (noteQueue.Count > 0)
        {
            Debug.Log($"{beat}, Time: {Time.time - t}");
            t = Time.time;
            
            if (noteQueue.First().time - 1 == beat)
            {
                Debug.Log($"Spawn Note : {noteQueue.First().type}");
                noteQueue.Dequeue();
            }
            
            // 다음 박자로 진행
            realTime += 60f / _bpm;
            beat++;
            yield return new WaitForSeconds(60f / _bpm);
        }
    }
}
