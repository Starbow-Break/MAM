using System;
using UnityEngine;
using System.Collections.Generic;

public class ContestSceneCharacterSetter : MonoBehaviour
{
    [SerializeField] private List<ACharacterSpot> _characterSpots = new List<ACharacterSpot>();
    [SerializeField] private CutsceneActor _originalActor = null;
    private readonly List<StudentCharacter> _characters = new List<StudentCharacter>();

    private static readonly float _spotFillPercent = 0.4f;
    public void Initialize()
    {
        //학생캐릭터 가져오기
        foreach (string id in GameManager.StudentManager.GetStudentIds())
        {
            StudentCharacter character = GameManager.StudentManager.GetStudentCharacter(id);
            character.transform.SetParent(transform);
            character.gameObject.SetActive(true);

            _characters.Add(character);
        }
        
        //학생배치
        _characterSpots.Shuffle();
        Queue<StudentCharacter> characterQueue = new Queue<StudentCharacter>(_characters);

        foreach (var spot in _characterSpots)
        {
            if (characterQueue.Count <= 0)
                break;

            spot.SetCharacter(characterQueue.Dequeue());
        }
        
        //NPC배치
        int leftSpots = _characterSpots.Count - _characters.Count;
        int characterCount = Mathf.FloorToInt(leftSpots * _spotFillPercent);
        for (int i = 0; i < characterCount; i++)
        {
            int index = i + _characters.Count;
            
            if (index >= _characterSpots.Count)
                break;
            
            CutsceneActor actor = Instantiate(_originalActor);
            actor.gameObject.SetActive(true);
            _characterSpots[index].SetCharacter(actor);
        }
    }
}
