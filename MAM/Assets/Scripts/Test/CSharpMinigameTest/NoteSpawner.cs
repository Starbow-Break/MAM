using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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

    [FormerlySerializedAs("noteDatas")] [SerializeField] private List<NoteUpdaterData> noteUpdaterDatas;
    [SerializeField] private Transform judgePoint;

    public void SpawnNote(NoteData noteData)
    {
        foreach (var noteUpdaterData in noteUpdaterDatas)
        {
            if (noteUpdaterData.Type == noteData.type && noteUpdaterData.NoteUpdater != null)
            {
                ANoteUpdater newUpdater = Instantiate(noteUpdaterData.NoteUpdater, transform.position, Quaternion.identity);
                newUpdater.SetBpm(120);
                newUpdater.SetDestination(transform.position);
                newUpdater.SetArrival(judgePoint.position);

                switch (noteData.type)
                {
                    case ENoteType.For:
                    {
                        ForNoteUpdater newUpdaterFor = newUpdater.GetComponent<ForNoteUpdater>();
                        newUpdaterFor.SetCount(noteData.count);
                        break;
                    }
                }
                break;
            }
        }
    }
}
