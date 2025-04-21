using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

// ReSharper disable All
public class TeamButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private List<Image> _teamMemberImages;
    [SerializeField] private SimpleRadioButton _radioButton;
    [SerializeField] private Sprite _emptySlotIcon = null;
    [SerializeField] private List<Image> _emptySlotMasks;

    private readonly float _minAlpha = 0.00392f;
    private Team _team;

    public SimpleRadioButton RadioButton => _radioButton;
    public Team Team
    {
        get { return _team; }
    }

    public void SetTeam(Team team)
    {
        _team = team;
        SetTeamMemberImage(0, team.Member1?.Icon);
        SetTeamMemberImage(1, team.Member2?.Icon);
    }

    public void SetTeamName(string teamName)
    {
        _teamName.text = teamName;
    }

    public void SetTeamMemberImage(int imageIndex, Sprite sprite)
    {
        Color color = _emptySlotMasks[imageIndex].color;
        color = _emptySlotMasks[imageIndex].color;

        if (sprite == null)
        {
            _teamMemberImages[imageIndex].sprite = _emptySlotIcon;
            
            color.a = 1f; 
            _emptySlotMasks[imageIndex].color = color;
            return;
        }
       
        _teamMemberImages[imageIndex].sprite = sprite;
        
        color.a = _minAlpha; 
        _emptySlotMasks[imageIndex].color = color;
    }
}
