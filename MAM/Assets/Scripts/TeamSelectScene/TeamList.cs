using UnityEngine;

public class TeamList : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _teamButton;
    
    public void SetTeamNumber(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_teamButton, _content);
        }
    }
}
