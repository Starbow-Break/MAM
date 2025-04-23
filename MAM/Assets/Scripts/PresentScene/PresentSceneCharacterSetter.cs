using UnityEngine;
using System.Collections.Generic;

public class PresentSceneCharacterSetter : MonoBehaviour
{
    [SerializeField] private List<ACharacterSpot> _characterSpots = new List<ACharacterSpot>();
    private List<StudentCharacter> _characters = new List<StudentCharacter>();
    
    public void Initialize()
    {
        foreach (string id in GameManager.StudentManager.GetStudentIds())
        {
            StudentCharacter character = GameManager.StudentManager.GetStudentCharacter(id);
            character.transform.SetParent(transform);
            character.gameObject.SetActive(true);

            _characters.Add(character);
        }
        
        _characterSpots.Shuffle();
        Queue<StudentCharacter> characterQueue = new Queue<StudentCharacter>(_characters);

        foreach (var spot in _characterSpots)
        {
            if (characterQueue.Count <= 0)
                return;

            spot.SetCharacter(characterQueue.Dequeue());
        }
    }
}
