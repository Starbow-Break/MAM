using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ChartDataParser
{
    private static readonly float MiliSecond = 0.001f;

    public static ChartData Parse(string chartDataPath)
    {
        var chartData = new ChartData();
        var path = Path.Combine(Application.streamingAssetsPath, chartDataPath);
        var json = File.ReadAllText(path);
        Debug.Log(json);

        var chartStartData = JsonUtility.FromJson<ChartStartData>(json);

        chartData.Bpm = chartStartData.bpm;
        chartData.Offset = chartStartData.offset * MiliSecond;
        chartData.Delay = chartStartData.delay * MiliSecond;
        foreach (var startNote in chartStartData.notes)
        {
            var noteData = new NoteData();
            noteData.Time = startNote.time;
            noteData.NoteType = ConvertStringToNoteType(startNote.type);
            noteData.Count = startNote.count;
            noteData.Color = startNote.color;
            noteData.Pattern = startNote.pattern;
            chartData.Notes.Add(noteData);
        }

        Debug.Log(chartData.Bpm);
        Debug.Log(chartData.Offset);
        foreach (var note in chartData.Notes)
        {
            //Debug.Log($"{note.Time} {note.NoteType} {note.Count} {note.Color} {note.Pattern}");
        }

        return chartData;
    }

    private static ENoteType ConvertStringToNoteType(string noteTypeStr)
    {
        var type = noteTypeStr switch
        {
            "normal" => ENoteType.Normal,
            "if" => ENoteType.If,
            "for" => ENoteType.For,
            _ => ENoteType.Normal
        };

        return type;
    }

    [Serializable]
    public struct ChartStartData
    {
        public string music_path; // 곡 파일 위치
        public float bpm; // 시작 BPM
        public float offset; // 오프셋
        public float delay; // 곡 재생 지연 시간

        public List<NoteStartData> notes; // 노트 정보
    }

    [Serializable]
    public struct NoteStartData
    {
        public int time; // 쳐야하는 시간
        public string type; // 노트 타입
        public int count; // 타격 수
        public Color color; // 색 (if 노트에서만 사용)
        public string pattern; // 스폰 후 패턴을 나타내는 문자열 (if 노트에서만 사용)
    }
}