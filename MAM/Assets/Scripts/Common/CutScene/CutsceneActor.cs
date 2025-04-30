using UnityEngine;
using UnityEngine.U2D.Animation;

public class CutsceneActor : BaseCharacter
{
    public void SetActor(string studentID)
    {
        _spriteLibrary.spriteLibraryAsset = GameManager.StudentManager.GetStudentSpriteLibrary(studentID);
        _spriteResolver.SetCategoryAndLabel(_startCategory, _startLabel);
    }
}
