using UnityEngine.U2D.Animation;
using UnityEngine;

[System.Serializable]
public struct ContestCharacterData
{
    public string ID;
    public string CharacterName;
    public Sprite CharacterIcon;
    public SpriteLibraryAsset SpriteLibraryAsset;

    public ContestCharacterData(string id, string characterName, Sprite characterIcon,
        SpriteLibraryAsset spriteLibraryAsset)
    {
        ID = id;
        CharacterName = characterName;
        CharacterIcon = characterIcon;
        SpriteLibraryAsset = spriteLibraryAsset;
    }

    public ContestCharacterData(Student student)
    {
        ID = student.ID;
        CharacterName = student.Name;
        CharacterIcon = student.Icon;
        SpriteLibraryAsset = GameManager.StudentManager.GetStudentSpriteLibrary(student.ID);
    }
}