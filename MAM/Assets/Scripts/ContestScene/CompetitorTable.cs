using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[System.Serializable]
public struct SpriteLibIconSet
{
    public Sprite Icon;
    public SpriteLibraryAsset SpriteLibraryAsset;
}

[CreateAssetMenu(fileName = "New CompetitorTable", menuName = "Scriptable Object/CompetitorTable")]
public class CompetitorTable : ScriptableObject
{
    public List<SpriteLibIconSet> SpriteLibraryAssets = new List<SpriteLibIconSet>();

    public float MinScore = 70;
    public float MaxScore = 98;
    
    public AnimationCurve ScoreDistributionCurve;

    public string BaseID = "Competitor";

    public int CompetitorCount = 26;
    
    public float GetRandomScore()
    {
        float rand= Random.value;
        float curveValue = ScoreDistributionCurve.Evaluate(rand);
        return Mathf.Lerp(MinScore, MaxScore,curveValue);
    }

    public void GetRandomLibraryAndIcon(out SpriteLibraryAsset libraryAsset, out Sprite icon)
    {
        int index = Random.Range(0, SpriteLibraryAssets.Count);
        libraryAsset = SpriteLibraryAssets[index].SpriteLibraryAsset;
        icon = SpriteLibraryAssets[index].Icon;
    }
}
