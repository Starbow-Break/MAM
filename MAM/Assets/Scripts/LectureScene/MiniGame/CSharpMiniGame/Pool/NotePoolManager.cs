using System;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-900)]
public class NotePoolManager : MonoBehaviour
{
    [SerializeField] private List<PoolData> _poolDatas;

    private readonly Dictionary<ENoteType, NotePool> _notePools = new();

    public static NotePoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this) Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (var poolData in _poolDatas) _notePools.Add(poolData.NoteType, poolData.Pool);
    }

    public ANoteUpdater SpawnNote(ENoteType noteType, Vector3 position, Quaternion rotation, Transform parent)
    {
        var noteUpdater = _notePools[noteType].Get();
        noteUpdater.transform.position = position;
        noteUpdater.transform.rotation = rotation;
        noteUpdater.transform.SetParent(parent, true);

        return noteUpdater;
    }

    public void ReleaseNote(ENoteType noteType, ANoteUpdater noteUpdater)
    {
        _notePools[noteType].Release(noteUpdater);
    }

    [Serializable]
    public struct PoolData
    {
        public ENoteType NoteType;
        public NotePool Pool;
    }
}