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
    public string FavRestaurant  = string.Empty;    //좋아하는 식당
    public EAffinityType AffinityType = EAffinityType.Carrot;
    
    public float CSharpSkill = 0;   //1~6
    public float UnitySkill = 0;    //1~6
    
    public float Motivation = 50f;   //의욕 0~100
    private float _intimacy = 0f;     //친밀도 0~100
    
    public Sprite Icon = null;

    public string ID { get { return _id; } }
    public float Intimacy {get {return _intimacy;} set {_intimacy = value;}}
    
    public Student(string id)
    {
        _id = id;
    }
}
