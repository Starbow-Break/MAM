using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisualizeCountSetter : MonoBehaviour
{
    [SerializeField] private GameObject UnitIcon;
    [SerializeField] private Transform _parent;
    [SerializeField] [Min(0)] private int startSpawnCount = 12;

    private readonly List<GameObject> unitIcons = new();

    public UnityAction<int> OnValueChanged;

    public int Value { get; private set; }

    private void OnEnable()
    {
        CSharpMiniGame.Controller.OnJudge += judgeInfo => OnJudge(judgeInfo);
    }

    private void OnDisable()
    {
        CSharpMiniGame.Controller.OnJudge -= judgeInfo => OnJudge(judgeInfo);
    }

    public void Initialize()
    {
        SetCount(startSpawnCount);
        SetCount(0);
    }

    private void OnJudge(JudgeInfo judgeInfo)
    {
        if (judgeInfo.NoteType == ENoteType.If && Value > 0) SetCount(Value - 1);
    }

    private void SpawnIcon()
    {
        var spawnedUnitIcon = Instantiate(UnitIcon, _parent);
        unitIcons.Add(spawnedUnitIcon);
    }

    public void SetCount(int count)
    {
        count = Mathf.Max(0, count);

        while (Value < count) AddCount();

        while (Value > count) DisCount();

        OnValueChanged?.Invoke(Value);
    }

    private void AddCount()
    {
        if (unitIcons.Count <= Value)
            SpawnIcon();
        else
            unitIcons[Value].SetActive(true);
        Value++;
    }

    private void DisCount()
    {
        if (Value <= 0) throw new Exception("Value couldn't less than 0");

        Value--;
        unitIcons[Value].SetActive(false);
    }
}