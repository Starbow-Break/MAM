using System;
using System.Collections.Generic;
using UnityEngine;

public enum EAffinityType
{
    Carrot,
    Whip
}

public enum ESkillType
{
    Unity,
    CSharp
}

[System.Serializable]
public class SkillLevel
{
    public ESkillType SkillType;
    public float Level;
}

[Serializable]
public class Student
{
    [SerializeField] string _id = string.Empty;
    
    public string Name = string.Empty;
    public string MBTI = string.Empty;
    public string FavRestaurant  = string.Empty;    //좋아하는 식당
    public EAffinityType AffinityType = EAffinityType.Carrot;
    
    public List<SkillLevel> Skills = new List<SkillLevel>();
    
    public float Motivation = 3f;   //의욕 1~5
    private float _intimacy = 0f;     //친밀도 0~100
    
    public Sprite Icon = null;

    public string ID { get { return _id; } }
    public float Intimacy {get {return _intimacy;} set {_intimacy = value;}}
    public float UnitySkill => GetSkillLevel(ESkillType.Unity); //1~6
    public float CSharpSkill => GetSkillLevel(ESkillType.CSharp); //1~6
    
    public Student(string id)
    {
        _id = id;
        
        SkillLevel skillLevelUnity = new SkillLevel();
        skillLevelUnity.SkillType = ESkillType.Unity;
        skillLevelUnity.Level = 1f;
        Skills.Add(skillLevelUnity);
        
        SkillLevel skillLevelCSharp = new SkillLevel();
        skillLevelCSharp.SkillType = ESkillType.CSharp;
        skillLevelCSharp.Level = 1f;
        Skills.Add(skillLevelCSharp);
    }
    
    public float GetSkillLevel(ESkillType skillType)
    {
        return Skills.Find(x => x.SkillType == skillType).Level;
    }

    public void SetSkillLevel(ESkillType skillType, float level)
    {
        Skills.Find(x => x.SkillType == skillType).Level = level;
    }
}
