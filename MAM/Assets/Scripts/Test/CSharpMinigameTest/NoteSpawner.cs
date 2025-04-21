using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct NoteData
    {
        [field: SerializeField]
        public ENoteType Type { get; private set; }
        [field: SerializeField]
        public ANoteUpdater NoteUpdater { get; private set; }
    }

    [SerializeField] private List<NoteData> noteDatas;
    [SerializeField] private Transform judgePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnNote(ENoteType.Normal);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnNote(ENoteType.If);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnNote(ENoteType.For);
        }
    }

    public void SpawnNote(ENoteType type)
    {
        foreach (var noteData in noteDatas)
        {
            if (noteData.Type == type)
            {
                ANoteUpdater newUpdater = Instantiate(noteData.NoteUpdater, transform.position, Quaternion.identity);
                newUpdater.SetBpm(120);
                newUpdater.SetDestination(transform.position);
                newUpdater.SetArrival(judgePoint.position);
                break;
            }
        }
    }
}
