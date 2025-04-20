using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class StudentCharacterGenerator : MonoBehaviour
{
    [SerializeField] private StudentSpriteLibraryTable _table = null;
    [SerializeField] private StudentCharacter _originalCharacter = null;
    
    private Dictionary<string, SpriteLibraryAsset> _lookup = null;

    private void Awake()
    {
        _lookup = new Dictionary<string, SpriteLibraryAsset>();
        
        foreach (var entry in _table.LibraryEntries)
        {
            bool success = _lookup.TryAdd(entry.Id, entry.SpriteLibrary);
            if(success == false)
                Debug.LogError("id 이상해");
        }
    }

    public StudentCharacter GetCharacter(string id)
    {
        StudentCharacter newStudentCharacter = Instantiate(_originalCharacter);

        newStudentCharacter.ID = id;
        
        if (_lookup.TryGetValue(id, out SpriteLibraryAsset asset))
        {
            newStudentCharacter.SetSpriteLibrary(asset);
        }
        else
        {
            
        }
        return newStudentCharacter;
    }
}
