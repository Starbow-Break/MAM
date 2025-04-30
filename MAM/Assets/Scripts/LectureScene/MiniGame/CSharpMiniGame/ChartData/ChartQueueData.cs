using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChartQueueData
{
    public List<EventQueueData> EventQueueDatas;
    public List<JudgeQueueData> JudgeQueueDatas;
    public List<SoundQueueData> SoundQueueDatas;
    
    public ChartQueueData()
    {
        EventQueueDatas = new List<EventQueueData>();
        JudgeQueueDatas = new List<JudgeQueueData>();
        SoundQueueDatas = new List<SoundQueueData>();
    }
}

[System.Serializable]
public class EventQueueData
{
    public float Time;  // 시간
    public EEventType EventType;    // 이벤트 타입
    public ENoteType NoteType;  // 노트 타입
    public float LifeTime;  // 생존 시간
    public Color Color; // 색
    public int Count;   // 갯수
}

[System.Serializable]
public class JudgeQueueData
{
    public float Time;  // 시간
    public ENoteType Type;  // 노트 타입
    public bool isHit; // 치는 노트 여부
}

[System.Serializable]
public class SoundQueueData
{
    public float Time;  // 시간
    public ESoundType SoundType;    // 효과음 타입
}