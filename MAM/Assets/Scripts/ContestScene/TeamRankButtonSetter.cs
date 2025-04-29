using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TeamRankButtonSetter : MonoBehaviour
{
    [SerializeField] private TeamRankButtonUpdater _originalUpdater = null;
    [SerializeField] private Transform _contentTransform = null;
    [SerializeField] private Button _continueButton = null;

    private List<TeamRankButtonUpdater> _viewers = new List<TeamRankButtonUpdater>();
    private RadioButtonGroup _teamGradeButtonGroup = null;
    
    private float _showButtonDelay = 1f;

    public void Initialize()
    {
        
    }
}
