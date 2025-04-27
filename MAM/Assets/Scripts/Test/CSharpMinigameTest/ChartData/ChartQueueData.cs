using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChartQueueData
{
    public List<EventQueueData> EventQueueDatas;
    public List<JudgeQueueData> JudgeQueueDatas;
    
    public ChartQueueData()
    {
        EventQueueDatas = new List<EventQueueData>();
        JudgeQueueDatas = new List<JudgeQueueData>();
    }
}

[System.Serializable]
public class EventQueueData
{
    public float Time;  // 시간
    public EEventType EventType;    // 이벤트 타입
    public ENoteType NoteType;  // 노트 타입
    public Vector3 SpawnPosition;   // 스폰 위치
    public float LifeTime;  // 생존 시간
    public Color Color; // 색
    public int Count;   // 갯수
}

[System.Serializable]
public class JudgeQueueData
{
    public float Time;  // 시간
    public ENoteType Type;  // 노트 타입
}