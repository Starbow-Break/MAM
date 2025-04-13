using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// ReSharper disable All
public class TeamButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private List<Image> _teamMemberImages;

    public int TeamID;

    public void SetTeamName(string teamName)
    {
        _teamName.text = teamName;
    }

    public void SetTeamMemberImage(int imageIndex, Sprite sprite)
    {
        _teamMemberImages[imageIndex].sprite = sprite;
    }
    
    public void SetSelected(bool selected)
    {
        // Todo : 임시
        GetComponent<Image>().color = selected ? Color.yellow : Color.white;
    }

    public void AddOnClickEventListener(UnityAction action)
    {
        GetComponent<TeamButton>().onClick.AddListener(action);
    }
}
