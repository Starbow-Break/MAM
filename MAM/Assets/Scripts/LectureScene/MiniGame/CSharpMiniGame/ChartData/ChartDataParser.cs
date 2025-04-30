using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public static class ChartDataParser
{
    private static readonly float MiliSecond = 0.001f;
    
    [System.Serializable]
    public struct ChartStartData
    {
        public string music_path;    // 곡 파일 위치
        public float bpm;  // 시작 BPM
        public float offset;    // 오프셋
        public float delay; // 곡 재생 지연 시간
        
        public List<NoteStartData> notes;   // 노트 정보
    }

    [System.Serializable]
    public struct NoteStartData
    {
        public int time;   // 쳐야하는 시간
        public string type; // 노트 타입
        public int count;  // 타격 수
        public Color color;    // 색 (if 노트에서만 사용)
        public string pattern; // 스폰 후 패턴을 나타내는 문자열 (if 노트에서만 사용)
    }
    
    public static ChartData Parse(string chartDataPath)
    {
        ChartData chartData = new ChartData();
        
        string json = File.ReadAllText(chartDataPath);
        Debug.Log(json);
        var chartStartData = JsonUtility.FromJson<ChartStartData>(json);
        
        AudioClip musicClip = AssetDatabase.LoadAssetAtPath<AudioClip>(chartStartData.music_path);
        chartData.MusicClip = musicClip;
        chartData.Bpm = chartStartData.bpm;
        chartData.Offset = chartStartData.offset * MiliSecond;
        chartData.Delay = chartStartData.delay * MiliSecond;
        foreach (var startNote in chartStartData.notes)
        {
            NoteData noteData = new NoteData();
            noteData.Time = startNote.time;
            noteData.NoteType = ConvertStringToNoteType(startNote.type);
            noteData.Count = startNote.count;
            noteData.Color = startNote.color;
            noteData.Pattern = startNote.pattern;
            chartData.Notes.Add(noteData);
        }
        
        Debug.Log(chartData.Bpm);
        Debug.Log(chartData.Offset);
        foreach (NoteData note in chartData.Notes)
        {
            Debug.Log($"{note.Time} {note.NoteType} {note.Count} {note.Color} {note.Pattern}");
        }
        
        return chartData;
    }

    private static ENoteType ConvertStringToNoteType(string noteTypeStr)
    {
        ENoteType type = noteTypeStr switch
        {
            "normal" => ENoteType.Normal,
            "if" => ENoteType.If,
            "for" => ENoteType.For,
            _ => ENoteType.Normal
        };

        return type;
    }
}
