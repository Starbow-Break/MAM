using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamProjectProgressUpdater : MonoBehaviour
{
    [Header("Team")]
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private Image _member1Icon;
    [SerializeField] private Image _member2Icon;
    
    [Header("Progress")]
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private Slider _progressbar;

    public Team Team { get; private set; }

    // 팀 정보 세팅
    public void SetTeam(Team team)
    {
        Team = team;
        _teamName.text = $"Team {team.TeamNumber}";
        _member1Icon.sprite = team.Member1?.Icon;
        _member2Icon.sprite = team.Member2?.Icon;
    }
    
    // 프로젝트 진행률 세팅
    public void SetProgress(float progress)
    {
        _progressText.text = $"{progress:f2}%";
        _progressbar.value = progress;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
