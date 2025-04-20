using UnityEngine;
using System.Collections.Generic;
using UnityEngine.U2D.Animation;

[System.Serializable]
public struct SpriteLibraryEntry
{
    public string Id;
    public SpriteLibraryAsset SpriteLibrary;
}

[CreateAssetMenu(fileName = "StudentSpriteLibraryTable", menuName = "Scriptable Object/StudentSpriteLibraryTable")]
public class StudentSpriteLibraryTable : ScriptableObject
{
    public List<SpriteLibraryEntry> LibraryEntries = new List<SpriteLibraryEntry>();
}

