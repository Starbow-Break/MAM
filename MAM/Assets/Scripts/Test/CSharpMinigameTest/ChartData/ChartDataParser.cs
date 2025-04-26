using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ChartDataParser
{
    [System.Serializable]
    public struct ChartStartData
    {
        public string title;    // 곡 제목
        public float bpm;  // 시작 BPM
        public float offset;    // 오프셋
        
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
    
    private const string testPath = "Assets/Scripts/Test/CSharpMinigameTest/ChartData/test.json";

    public static ChartData Parse(string chartDataPath = testPath)
    {
        ChartData chartData = new ChartData();
        
        string json = File.ReadAllText(chartDataPath);
        Debug.Log(json);
        var chartStartData = JsonUtility.FromJson<ChartStartData>(json);
        
        chartData.title = chartStartData.title;
        chartData.bpm = chartStartData.bpm;
        chartData.offset = chartStartData.offset;
        foreach (var startNote in chartStartData.notes)
        {
            NoteData noteData = new NoteData();
            noteData.time = startNote.time;
            noteData.type = ConvertStringToNoteType(startNote.type);
            noteData.count = startNote.count;
            noteData.color = startNote.color;
            noteData.pattern = startNote.pattern;
            chartData.notes.Add(noteData);
        }
        
        Debug.Log(chartData.title);
        Debug.Log(chartData.bpm);
        Debug.Log(chartData.offset);
        foreach (NoteData note in chartData.notes)
        {
            Debug.Log($"{note.time} {note.type} {note.count} {note.color} {note.pattern}");
        }
        
        return chartData;
    }

    private static ENoteType ConvertStringToNoteType(string noteTypeStr)
    {
        Debug.Log(noteTypeStr);
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
