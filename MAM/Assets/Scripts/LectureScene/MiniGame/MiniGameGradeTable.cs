using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MiniGameGradeData
{
    public string Grade;
    public float Score;
    public Color TextColor;
}

[CreateAssetMenu(fileName = "MiniGameGradeTable", menuName = "Scriptable Object/MiniGameGradeTable")]
public class MiniGameGradeTable : ScriptableObject
{
    [Header("내림차순 정렬")] public List<MiniGameGradeData> GradeDatas = new();

    public void GetGradeData(float score, out string grade, out Color color)
    {
        var data = GradeDatas.Find(grade => grade.Score <= score);

        if (data.Equals(default(MiniGameGradeData))) data = GradeDatas[GradeDatas.Count - 1];

        grade = data.Grade;
        color = data.TextColor;
    }
}