using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public struct StudentStartData
{
    public string ID;
    
    public string Name;
    public string MBTI;
    public string FavRestaurant;
    public EAffinityType AffinityType;

    public int CSharpSkill;
    public int UnitySkill;
    
    public Sprite Icon;
}


[CreateAssetMenu(fileName = "StudentStartDataTable", menuName = "Scriptable Object/StudentStartDataTable")]
public class StudentStartDataTable : ScriptableObject
{
#if UNITY_EDITOR
    public string URL_ID = "1geUI-yXY5iO3cqlfqMH_vRGQ5TQjIyalk7tYtBUhAVA";
    public string URL_SHEET = "0";
#endif

    
    public List<StudentStartData> StudentStartDataList = new List<StudentStartData>();
}
