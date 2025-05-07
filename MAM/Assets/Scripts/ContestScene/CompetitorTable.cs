using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[System.Serializable]
public struct SpriteLibIconSet
{
    public Sprite Icon;
    public SpriteLibraryAsset SpriteLibraryAsset;
}

[System.Serializable]
public struct CompetitorScoreRange
{
    public float Min;
    public float Max;
}

[CreateAssetMenu(fileName = "New CompetitorTable", menuName = "Scriptable Object/CompetitorTable")]
public class CompetitorTable : ScriptableObject
{
    public List<SpriteLibIconSet> SpriteLibraryAssets = new();

    public List<CompetitorScoreRange> CompetitorScores = new();

    public AnimationCurve ScoreDistributionCurve;

    public string BaseID = "Competitor";

    public List<string> LastNames = new();
    public List<string> FirstNames = new();
    
    public int CompetitorCount = 5;
    
    public float GetRandomScore(int index)   //index가 낮을수록 높은점수
    {
        index = Mathf.Clamp(index, 0, CompetitorScores.Count);
        
        float rand = Random.value;
        float curveValue = ScoreDistributionCurve.Evaluate(rand);
        
        float min = CompetitorScores[index].Min;
        float max = CompetitorScores[index].Max;
        
        return Mathf.Lerp(min, max,curveValue);
    }

    public void GetRandomLibraryAndIcon(out SpriteLibraryAsset libraryAsset, out Sprite icon)
    {
        int index = Random.Range(0, SpriteLibraryAssets.Count);
        libraryAsset = SpriteLibraryAssets[index].SpriteLibraryAsset;
        icon = SpriteLibraryAssets[index].Icon;
    }
    
    public string GetRandomName()
    {
        string randomName = string.Empty;
        int index = Random.Range(0, LastNames.Count);
        randomName = LastNames[index];
        index = Random.Range(0, FirstNames.Count);
        randomName += FirstNames[index];
        
        return randomName;
    }
}
