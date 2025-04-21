using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct NoteData
    {
        public ENoteType Type { get; private set; }
        public GameObject NotePrefab { get; private set; }
    }

    [SerializeField] private List<NoteData> noteDatas;

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
                Instantiate(noteData.NotePrefab, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
