using System;
using UnityEngine;

public enum EAffinityType
{
    Carrot,
    Whip
}


[Serializable]
public class Student
{
    [SerializeField] string _id = string.Empty;
    
    public string Name = string.Empty;
    public string MBTI = string.Empty;
    public string FavRestaurant  = string.Empty;
    public EAffinityType AffinityType = EAffinityType.Carrot;
    
    public int CSharpSkill = 0;
    public int UnitySkill = 0;
    
    public float Motivation = 50f;   //의욕 0~100
    public float Intimacy = 0f;     //친밀도 0~100
    
    public Sprite Icon = null;

    public string ID { get { return _id; } }

    public Student(string id)
    {
        _id = id;
    }
}
