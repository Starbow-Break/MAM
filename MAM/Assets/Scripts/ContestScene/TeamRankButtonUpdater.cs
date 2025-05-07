using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;

public class TeamRankButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamRank;
    [SerializeField] private List<Image> _teamMemberImages;
    [SerializeField] private List<TextMeshProUGUI> _teamMemeberNames;
    [SerializeField] private SimpleRadioButton _radioButton;
    [SerializeField] private TextMeshProUGUI _gradeText;

    private ContestTeam _team;

    public SimpleRadioButton RadioButton => _radioButton;
    public ContestTeam Team
    {
        get { return _team; }
    }

    public void SetRank(int rank)
    {
        _teamRank.text = rank.ToString();
    }
    
    public void SetTeam(ContestTeam team)
    {
        _team = team;
        
        _teamMemberImages[0].sprite = team.Members[0].CharacterIcon;
        _teamMemeberNames[0].text = team.Members[0].CharacterName;

        _teamMemberImages[1].sprite = team.Members[1].CharacterIcon;
        _teamMemeberNames[1].text = team.Members[1].CharacterName;
        
        SetGrade(team.ProjectScore);
    }
    
    private void SetGrade(float score)
    {
        _gradeText.text = Mathf.Floor(score).ToString();
    }
}
