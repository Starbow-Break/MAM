using System;
using System.Collections.Generic;
using UnityEngine;

public static class ChartQueueDataGenerator
{
    private static readonly Color DefaultColor = Color.green;
    private static readonly Color[] IfNoteColors = { Color.red, Color.blue };

    public static ChartQueueData Generate(ChartData chartData)
    {
        var chartQueueData = new ChartQueueData();

        var bpm = chartData.Bpm;
        var offset = chartData.Offset;
        var delay = chartData.Delay;

        foreach (var noteData in chartData.Notes)
            switch (noteData.NoteType)
            {
                case ENoteType.Normal:
                {
                    var spawnData = GenerateBaseSpawnData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(spawnData);
                    var judgeDatas = GenerateJudgeDatas(bpm, offset, noteData);
                    chartQueueData.JudgeQueueDatas.AddRange(judgeDatas);

                    var soundQueueData = new List<SoundQueueData>();

                    var spawnSoundData = new SoundQueueData();
                    spawnSoundData.Time = spawnData.Time;
                    spawnSoundData.SoundType = ESoundType.NoteSpawn;
                    soundQueueData.Add(spawnSoundData);

                    foreach (var data in judgeDatas)
                    {
                        var soundData = new SoundQueueData();
                        soundData.Time = data.Time;
                        soundData.SoundType = ESoundType.Hit;
                        soundQueueData.Add(soundData);
                    }

                    chartQueueData.SoundQueueDatas.AddRange(soundQueueData);
                    break;
                }
                case ENoteType.If:
                {
                    var visualizeData = GenerateBaseVisualizeData(bpm, offset, noteData);
                    visualizeData.Color = noteData.Color;
                    chartQueueData.EventQueueDatas.Add(visualizeData);

                    var soundQueueData = new List<SoundQueueData>();

                    for (var i = 0; i < noteData.Pattern.Length; i++)
                    {
                        var spawnData = GenerateBaseSpawnData(bpm, offset, noteData);
                        spawnData.Time += 60f / bpm * 2 * i;

                        Debug.Log(noteData.Color);
                        var colorIndex = (Array.IndexOf(IfNoteColors, noteData.Color) +
                                          (noteData.Pattern[i] == '1' ? 0 : 1)) % 2;
                        var color = IfNoteColors[colorIndex];
                        spawnData.Color = color;
                        chartQueueData.EventQueueDatas.Add(spawnData);

                        var spawnSoundData = new SoundQueueData();
                        spawnSoundData.Time = spawnData.Time;
                        spawnSoundData.SoundType = ESoundType.NoteSpawn;
                        soundQueueData.Add(spawnSoundData);
                    }

                    var judgeDatas = GenerateJudgeDatas(bpm, offset, noteData);
                    for (var i = 0; i < noteData.Pattern.Length; i++) judgeDatas[i].isHit = noteData.Pattern[i] == '1';
                    chartQueueData.JudgeQueueDatas.AddRange(judgeDatas);

                    foreach (var data in judgeDatas)
                    {
                        var soundData = new SoundQueueData();
                        soundData.Time = data.Time;
                        soundData.SoundType = ESoundType.Hit;
                        soundQueueData.Add(soundData);
                    }

                    chartQueueData.SoundQueueDatas.AddRange(soundQueueData);

                    break;
                }
                case ENoteType.For:
                {
                    var visualizeData = GenerateBaseVisualizeData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(visualizeData);
                    var spawnData = GenerateBaseSpawnData(bpm, offset, noteData);
                    chartQueueData.EventQueueDatas.Add(spawnData);
                    var judgeDatas = GenerateJudgeDatas(bpm, offset, noteData);
                    for (var i = 0; i < noteData.Count - 1; i++) judgeDatas[i].Type = ENoteType.ForBullet;
                    chartQueueData.JudgeQueueDatas.AddRange(judgeDatas);

                    var soundQueueData = new List<SoundQueueData>();

                    var spawnSoundData = new SoundQueueData();
                    spawnSoundData.Time = spawnData.Time;
                    spawnSoundData.SoundType = ESoundType.NoteSpawn;
                    soundQueueData.Add(spawnSoundData);

                    foreach (var data in judgeDatas)
                    {
                        var soundData = new SoundQueueData();
                        soundData.Time = data.Time;
                        soundData.SoundType = ESoundType.Hit;
                        soundQueueData.Add(soundData);
                    }

                    chartQueueData.SoundQueueDatas.AddRange(soundQueueData);

                    break;
                }
            }

        chartQueueData.EventQueueDatas.Sort((a, b) => a.Time.CompareTo(b.Time));
        chartQueueData.JudgeQueueDatas.Sort((a, b) => a.Time.CompareTo(b.Time));
        chartQueueData.SoundQueueDatas.Sort((a, b) => a.Time.CompareTo(b.Time));

        return chartQueueData;
    }

    private static EventQueueData GenerateBaseVisualizeData(float bpm, float offset, NoteData noteData)
    {
        var data = new EventQueueData();
        data.Time = (noteData.Time - 1) * 60f / bpm + offset;
        data.EventType = EEventType.Visualize;
        data.NoteType = noteData.NoteType;
        data.LifeTime = 60f / bpm;
        data.Color = DefaultColor;
        data.Count = noteData.Count;

        return data;
    }

    private static EventQueueData GenerateBaseSpawnData(float bpm, float offset, NoteData noteData)
    {
        var data = new EventQueueData();

        data.Time = (noteData.Time - 1) * 60f / bpm + offset;
        data.EventType = EEventType.Spawn;
        data.NoteType = noteData.NoteType;
        data.LifeTime = 60f / bpm;
        data.Color = DefaultColor;
        data.Count = noteData.Count;

        return data;
    }

    private static List<JudgeQueueData> GenerateJudgeDatas(float bpm, float offset, NoteData noteData)
    {
        var datas = new List<JudgeQueueData>();

        var add = 0f;
        for (var i = 0; i < noteData.Count; i++)
        {
            var data = new JudgeQueueData();
            data.Time = noteData.Time * 60f / bpm + offset + add;
            data.Type = noteData.NoteType;
            data.isHit = true;

            switch (noteData.NoteType)
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