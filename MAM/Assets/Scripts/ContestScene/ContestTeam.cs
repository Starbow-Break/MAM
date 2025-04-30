using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContestTeam
{
    public List<ContestCharacterData> Members = new List<ContestCharacterData>();
    public float ProjectScore = 0;
    public bool IsPlayerTeam = false;

    public ContestTeam(ContestCharacterData character1, ContestCharacterData character2, float projectScore, bool isPlayerTeam)
    {
        Members.Add(character1);
        Members.Add(character2);
        ProjectScore = projectScore;
        IsPlayerTeam = isPlayerTeam;
    }
}
