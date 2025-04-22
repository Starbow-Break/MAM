using System.Collections.Generic;
using UnityEngine;

public abstract class ADoubleCharacterSpot : ACharacterSpot
{
    [SerializeField] protected Transform _characterPosition2 = null;
    public override void SetCharacter(StudentCharacter character)
    {
        character.transform.position = _characterPosition.position;
    }
    
    public abstract void SetCharacters(StudentCharacter character, StudentCharacter character2);
}
