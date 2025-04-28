using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct NoteUpdaterData
    {
        [field: SerializeField]
        public ENoteType Type { get; private set; }
        [field: SerializeField]
        public ANoteUpdater NoteUpdater { get; private set; }
    }

    [SerializeField] private List<NoteUpdaterData> noteUpdaterDatas;
    [SerializeField] private Transform destroyPoint;

    public UnityAction<ENoteType> OnSpawnedNote;

    public void SpawnNote(EventQueueData data)
    {
        foreach (var noteUpdaterData in noteUpdaterDatas)
        {
            if (noteUpdaterData.Type == data.NoteType && noteUpdaterData.NoteUpdater != null)
            {
                ANoteUpdater newUpdater = NotePoolManager.Instance.SpawnNote(data.NoteType, transform.position, Quaternion.identity, transform);
                newUpdater.SetArriveTime(data.LifeTime);
                newUpdater.SetDestination(transform.position);
                newUpdater.SetArrival(destroyPoint.position);

                switch (data.NoteType)
                {
                    case ENoteType.If:
                    {
                        IfNoteUpdater newUpdaterIf = newUpdater.GetComponent<IfNoteUpdater>();
                        newUpdaterIf.SetColor(data.Color);
                        break;
                    }
                    case ENoteType.For:
                    {
                        ForNoteUpdater newUpdaterFor = newUpdater.GetComponent<ForNoteUpdater>();
                        newUpdaterFor.SetCount(data.Count);
                        break;
                    }
                }
                
                OnSpawnedNote?.Invoke(data.NoteType);
                break;
            }
        }
    }
}
