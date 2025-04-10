using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable All
public class TeamButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private List<Image> _teamMemberImages;
    [SerializeField] private Button _button;

    public void SetTeamName(string teamName)
    {
        _teamName.text = teamName;
    }

    public void SetTeamMemberImage(Sprite sprite)
    {
        for (int i = 0; i < _teamMemberImages.Count; i++)
        {
            if (_teamMemberImages[i].sprite == null)
            {
                _teamMemberImages[i].sprite = sprite;
                break;
            }
        }
    }

    public void RemoveTeamMemberImage(Sprite sprite)
    {
        for (int i = 0; i < _teamMemberImages.Count; i++)
        {
            if (_teamMemberImages[i].sprite != null)
            {
                _teamMemberImages[i].sprite = null;
                break;
            }
        }
    }
}
