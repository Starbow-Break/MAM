using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct MusicData
{
    public string musicTitle;
    public AudioClip musicClip;
    public string Level1ChartPath;
    public string Level2ChartPath;
    public string Level3ChartPath;

    public string GetChartPath(int difficulty)
    {
        var path = difficulty switch
        {
            1 => Level1ChartPath,
            2 => Level2ChartPath,
            3 => Level3ChartPath,
            _ => string.Empty
        };

        return path;
    }
}

[CreateAssetMenu(fileName = "MusicDataTable", menuName = "Scriptable Object/MusicDataTable", order = 0)]
public class MusicDataTable : ScriptableObject
{
    [SerializeField] private List<MusicData> _musicDatas;
    private bool _initializeDict;

    private Dictionary<string, MusicData> _musicDataDict;

    public MusicData GetMusicData(string MusicTitle)
    {
        if (!_initializeDict) InitializeMusicDataDictionary();

        if (!_musicDataDict.TryGetValue(MusicTitle, out var musicData))
            throw new Exception($"{MusicTitle} MusicData Does not Exist.");

        return musicData;
    }

    public MusicData GetMusicDataRandomly()
    {
        if (_musicDatas.Count <= 0) throw new Exception("MusicData Does not Exist.");

        var index = Random.Range(0, _musicDatas.Count);
        return _musicDatas[index];
    }

    private void InitializeMusicDataDictionary()
    {
        _musicDataDict = new Dictionary<string, MusicData>();

        foreach (var musicData in _musicDatas) _musicDataDict.Add(musicData.musicTitle, musicData);

        _initializeDict = true;
    }
}