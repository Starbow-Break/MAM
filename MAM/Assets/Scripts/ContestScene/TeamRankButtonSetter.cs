using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class TeamRankButtonSetter : MonoBehaviour
{
    [SerializeField] private TeamRankButtonUpdater _originalUpdater = null;
    [SerializeField] private Transform _contentTransform = null;
    [SerializeField] private Button _continueButton = null;

    private List<TeamRankButtonUpdater> _updaters = new List<TeamRankButtonUpdater>();

    private RadioButtonGroup _buttonGroup = null;
    
    private float _showButtonDelay = 1f;
    private static readonly int _buttonCount = 5;
    
    public void Initialize()
    {
        List<ContestTeam> contestTeams = ContestSceneManager.Teams;
        List<SimpleRadioButton> buttons = new List<SimpleRadioButton>();

        contestTeams.Sort((a,b) =>b.ProjectScore.CompareTo(a.ProjectScore));
        
        for (int i = _buttonCount; i > 0; i--)
        {
            TeamRankButtonUpdater newUpdater = Instantiate(_originalUpdater, _contentTransform);
            
            newUpdater.SetTeam(contestTeams[i]);
            newUpdater.gameObject.SetActive(false);
            newUpdater.SetRank(i);
            _updaters.Add(newUpdater);

            newUpdater.RadioButton.ActOnClick += () =>
            {
                ContestSceneManager.ActOnTeamSelected?.Invoke(newUpdater.Team);
            };
            buttons.Add(newUpdater.RadioButton);
        }
        
        _buttonGroup = new RadioButtonGroup(buttons.ToArray());
        _buttonGroup.OnValueChanged += OnTeamSelected;
        _buttonGroup.DisableAllButtons();
        
        //계속버튼
        _continueButton.gameObject.SetActive(false);
        _continueButton.onClick.AddListener(GameManager.FlowManager.ToNextScene);
    }
    
    private void OnTeamSelected(int teamIndex)
    {
        
    }
    
    public void ShowButtons()
    {
        StartCoroutine(ShowTeamButtonsCo());
    }

    private IEnumerator ShowTeamButtonsCo()
    {
        foreach (TeamRankButtonUpdater updater in _updaters)
        {
            updater.transform.SetAsFirstSibling();
            updater.gameObject.SetActive(true);
            
            ContestSceneManager.ActOnTeamSelected?.Invoke(updater.Team);
            
            yield return new WaitForSeconds(_showButtonDelay);
        }
        
        _continueButton.gameObject.SetActive(true);
        _buttonGroup.EnableAllButtons();
    }
}
