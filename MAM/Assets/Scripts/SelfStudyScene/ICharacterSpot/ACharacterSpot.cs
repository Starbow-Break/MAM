using UnityEngine;

[System.Serializable]
public abstract class ACharacterSpot : MonoBehaviour
{
    [SerializeField] protected Transform _characterPosition = null;
    
    public abstract void SetCharacter(BaseCharacter character);
}
