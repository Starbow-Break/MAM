using System;
using System.Collections.Generic;
using UnityEngine;

public static class ChartQueueDataGenerator
{
    private static readonly float MiliSecond = 0.001f;
    private static readonly Color DefaultColor = Color.green;
    private static readonly Color[] IfNoteColors = { Color.red, Color.blue };
    
    public static ChartQueueData Generate(ChartData chartData)
    {
        ChartQueueData chartQueueData = new ChartQueueData();

        float bpm = chartData.bpm;
        float offset = chartData.offset * MiliSecond;

        foreach (var noteData in chartData.notes)
        {
            switch (noteData.type)
            {
                case ENoteType.Normal:
                {
                    var spawnData = GenerateBaseSpawnData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(spawnData);
                    var judgeDatas = GenerateJudgeDatas(bpm, offset, noteData);
                    chartQueueData.JudgeQueueDatas.AddRange(judgeDatas);
                    break;
                }
                case ENoteType.If:
                {
                    var visualizeData = GenerateBaseVisualizeData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(visualizeData);
                    
                    for(int i = 0; i < noteData.pattern.Length; i++)
                    {
                        var spawnData = GenerateBaseSpawnData(bpm, offset, noteData);
                        spawnData.Time += 60f / bpm * 2 * i;
                        
                        Debug.Log(noteData.color);
                        int colorIndex = (Array.IndexOf(IfNoteColors, noteData.color) + (noteData.pattern[i] == '1' ? 0 : 1)) % 2;
                        Color color = IfNoteColors[colorIndex];
                        spawnData.Color = color;
                        chartQueueData.EventQueueDatas.Add(spawnData);
                    }
                    
                    var judgeDatas = GenerateJudgeDatas(bpm, offset, noteData);
                    chartQueueData.JudgeQueueDatas.AddRange(judgeDatas);
                    break;
                }
                case ENoteType.For:
                {
                    var visualizeData = GenerateBaseVisualizeData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(visualizeData);
                    var spawnData = GenerateBaseSpawnData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(spawnData);
                    var judgeDatas = GenerateJudgeDatas(bpm, offset, noteData);
                    chartQueueData.JudgeQueueDatas.AddRange(judgeDatas);
                    break;    
                }
            }
        }
        
        chartQueueData.EventQueueDatas.Sort((a, b) => a.Time.CompareTo(b.Time));
        
        return chartQueueData;
    }

    private static EventQueueData GenerateBaseVisualizeData(float bpm, float offset, NoteData noteData)
    {
        EventQueueData data = new EventQueueData();
        data.Time = (noteData.time - 2) * 60f / bpm + offset;
        data.EventType = EEventType.Visualize;
        data.NoteType = noteData.type;
        data.SpawnPosition = Vector3.zero;
        data.LifeTime = 60f / bpm;
        data.Color = DefaultColor;
        data.Count = noteData.count;

        return data;
    }
    
    private static EventQueueData GenerateBaseSpawnData(float bpm, float offset, NoteData noteData)
    {
        EventQueueData data = new EventQueueData();
        
        data.Time = (noteData.time - 1) * 60f / bpm + offset;
        data.EventType = EEventType.Spawn;
        data.NoteType = noteData.type;
        data.SpawnPosition = Vector3.zero;
        data.LifeTime = 60f / bpm;
        data.Color = DefaultColor;
        data.Count = noteData.count;

        return data;
    }
    
    private static List<JudgeQueueData> GenerateJudgeDatas(float bpm, float offset, NoteData noteData)
    {
        List<JudgeQueueData> datas = new List<JudgeQueueData>();

        float add = 0f;
        for (int i = 0; i < noteData.count; i++)
        {
            JudgeQueueData data = new JudgeQueueData();
            data.Time = noteData.time * 60f / bpm + offset + add;
            data.Type = noteData.type;

            switch (noteData.type)
            {
                case ENoteType.If:
                    add += 60f / bpm * 2f;
                    break;
                case ENoteType.For:
                    add += 60f / bpm;
                    break;
            }
            
            datas.Add(data);
        }

        return datas;
    }

}
