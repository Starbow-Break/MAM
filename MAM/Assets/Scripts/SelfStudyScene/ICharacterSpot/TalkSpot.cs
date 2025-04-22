using UnityEngine;

public class TalkSpot : ADoubleCharacterSpot
{
    public override void SetCharacters(StudentCharacter character, StudentCharacter character2)
    {
        character.transform.SetParent(_characterPosition);
        character.transform.position = _characterPosition.position;
        character.Animator.TurnRight();
        
        character2.transform.SetParent(_characterPosition2);
        character2.transform.position = _characterPosition2.position;
        character2.Animator.TurnLeft();    
    }
}
