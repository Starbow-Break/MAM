using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private List<NoteUpdaterData> noteUpdaterDatas;
    [SerializeField] private Transform destroyPoint;

    public void SpawnNote(EventQueueData data)
    {
        foreach (var noteUpdaterData in noteUpdaterDatas)
            if (noteUpdaterData.Type == data.NoteType && noteUpdaterData.NoteUpdater != null)
            {
                var newUpdater = NotePoolManager.Instance.SpawnNote(data.NoteType, transform.position,
                    Quaternion.identity, transform);
                newUpdater.SetArriveTime(data.LifeTime);
                newUpdater.SetDestination(transform.position);
                newUpdater.SetArrival(destroyPoint.position);

                switch (data.NoteType)
                {
                    case ENoteType.If:
                    {
                        var newUpdaterIf = newUpdater.GetComponent<IfNoteUpdater>();
                        newUpdaterIf.SetColor(data.Color);
                        break;
                    }
                    case ENoteType.For:
                    {
                        var newUpdaterFor = newUpdater.GetComponent<ForNoteUpdater>();
                        newUpdaterFor.SetCount(data.Count);
                        break;
                    }
                }

                break;
            }
    }

    [Serializable]
    public struct NoteUpdaterData
    {
        [field: SerializeField] public ENoteType Type { get; private set; }
        [field: SerializeField] public ANoteUpdater NoteUpdater { get; private set; }
    }
}