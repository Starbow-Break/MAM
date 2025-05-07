using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChartData
{
    public AudioClip MusicClip; // 곡
    public float Bpm; // 시작 BPM
    public float Offset; // 오프셋
    public float Delay; // 곡 재생 지연 시간

    public List<NoteData> Notes; // 노트 정보

    public ChartData()
    {
        Notes = new List<NoteData>();
    }
}

[Serializable]
public class NoteData
{
    public int Time; // 쳐야하는 시간
    public ENoteType NoteType; // 노트 타입
    public int Count; // 타격 수
    public Color Color; // 색 (if 노트에서만 사용)
    public string Pattern; // 스폰 후 패턴을 나타내는 문자열 (if 노트에서만 사용)
}