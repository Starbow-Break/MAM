using UnityEngine;

public class ChairSpot : ACharacterSpot
{
    [SerializeField] private GameObject _fullChairImage = null;
    [SerializeField] private GameObject _chairArmImage = null;
    
    private StudentCharacter _character = null;
    
    public override void SetCharacter(StudentCharacter character)
    {
        _character = character;
        _character.transform.SetParent(_characterPosition);
        _character.transform.position = _characterPosition.position;
        _character.Animator.TurnBack();
        
        _fullChairImage.SetActive(false);
        _chairArmImage.SetActive(true);
    }
}
