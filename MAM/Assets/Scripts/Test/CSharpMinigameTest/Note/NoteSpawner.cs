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

    public void SpawnNote(NoteData noteData)
    {
        foreach (var noteUpdaterData in noteUpdaterDatas)
        {
            if (noteUpdaterData.Type == noteData.type && noteUpdaterData.NoteUpdater != null)
            {
                ANoteUpdater newUpdater = Instantiate(noteUpdaterData.NoteUpdater, transform.position, Quaternion.identity);
                newUpdater.SetBpm(120);
                newUpdater.SetDestination(transform.position);
                newUpdater.SetArrival(destroyPoint.position);

                switch (noteData.type)
                {
                    case ENoteType.For:
                    {
                        ForNoteUpdater newUpdaterFor = newUpdater.GetComponent<ForNoteUpdater>();
                        newUpdaterFor.SetCount(noteData.count);
                        break;
                    }
                }
                
                OnSpawnedNote?.Invoke(noteData.type);
                break;
            }
        }
    }
}
