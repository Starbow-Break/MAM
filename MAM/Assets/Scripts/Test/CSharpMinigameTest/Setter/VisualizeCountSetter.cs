using System.Collections.Generic;
using UnityEngine;

public class VisualizeCountSetter : MonoBehaviour
{
    [SerializeField] private GameObject UnitIcon;
    [SerializeField] private Transform _parent;
    [SerializeField] private NoteSpawner _noteSpawner;
    [SerializeField, Min(0)] private int startSpawnCount = 12;

    List<GameObject> unitIcons = new();

    public int Value { get; private set; } = 0;
    
    private void OnEnable()
    {
        _noteSpawner.OnSpawnedNote += noteType => OnSpawnedNote(noteType);
    }
    
    private void OnDisable()
    {
        _noteSpawner.OnSpawnedNote -= noteType => OnSpawnedNote(noteType);
    }

    public void Initialize()
    {
        SetCount(startSpawnCount);
        SetCount(0);
    }

    private void OnSpawnedNote(ENoteType noteType)
    {
        if (noteType == ENoteType.If)
        {
            DisCount();
        }
    }

    private void SpawnIcon()
    {
        GameObject spawnedUnitIcon = Instantiate(UnitIcon, _parent);
        unitIcons.Add(spawnedUnitIcon);
    }

    public void SetCount(int count)
    {
        count = Mathf.Max(0, count);
        
        while (Value < count)
        {
            AddCount();
        }

        while (Value > count)
        {
            DisCount();
        }
    }

    public void AddCount()
    {
        if (unitIcons.Count <= Value)
        {
            SpawnIcon();
        }
        else
        {
            unitIcons[Value].SetActive(true);
        }
        Value++;
    }

    public void DisCount()
    {
        Value--;
        unitIcons[Value].SetActive(false);
    }
}
