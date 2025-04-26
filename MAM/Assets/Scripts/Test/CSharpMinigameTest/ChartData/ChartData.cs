using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChartData
{
    public string title;    // 곡 제목
    public float bpm;  // 시작 BPM
    public float offset;    // 오프셋
        
    public List<NoteData> notes;   // 노트 정보

    public ChartData()
    {
        notes = new List<NoteData>();
    }
}
    
[System.Serializable]
public class NoteData
{
    public int time;   // 쳐야하는 시간
    public ENoteType type; // 노트 타입
    public int count;  // 타격 수
    public Color color;    // 색 (if 노트에서만 사용)
    public string pattern; // 스폰 후 패턴을 나타내는 문자열 (if 노트에서만 사용)
}

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