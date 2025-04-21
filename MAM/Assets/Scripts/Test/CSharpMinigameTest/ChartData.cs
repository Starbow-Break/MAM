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
