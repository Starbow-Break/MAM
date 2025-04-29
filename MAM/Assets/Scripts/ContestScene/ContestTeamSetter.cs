using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ContestTeamSetter : MonoBehaviour
{
    [SerializeField] private CompetitorTable _table = null;

    private List<ContestTeam> _teams = new List<ContestTeam>();
    
    public List<ContestTeam> GetTeams => _teams;

    public void Initialize()
    {
        //학생들 전환
        foreach (Team team in GameManager.TeamManager.GetTeams())
        {
            ContestCharacterData member1 = new ContestCharacterData(team.Member1);
            ContestCharacterData member2 = new ContestCharacterData(team.Member2);
            float score = team.ProjectProgress;
            
            ContestTeam newContestTeam = new ContestTeam(member1, member2, score, true);
            _teams.Add(newContestTeam);
        }
        
        //다른학생들 생성
        for (int i = 0; i < _table.CompetitorCount; i++)
        {
            ContestTeam newContestTeam = GenerateRandomTeam(i);
            _teams.Add(newContestTeam);
        }
    }

    private ContestTeam GenerateRandomTeam(int index)
    {
        ContestCharacterData member1 = GenerateRandomCharacter(index, 0);
        ContestCharacterData member2 = GenerateRandomCharacter(index, 1);
        
        float score = _table.GetRandomScore();
        
        ContestTeam newTeam = new ContestTeam(member1, member2, score, false);
        
        return newTeam;
    }

    private ContestCharacterData GenerateRandomCharacter(int index, int memberNum)
    {
        string id = _table.BaseID + index.ToString() + memberNum.ToString();
        _table.GetRandomLibraryAndIcon(out var libraryAsset, out var sprite);
        string name = KoreanNameGenerator.GetRandomKoreanName();
        
        ContestCharacterData character = new ContestCharacterData(id, name, sprite, libraryAsset);
        
        return character;
    }
}
