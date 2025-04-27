using UnityEngine;

public class JudgeInfo
{
    public EJudge Judge;
    public bool IsHit;
    public Sprite NoteSprite;
    public Color NoteColor;
    public Quaternion NoteRotation;
    public Vector3 NoteScale;   

    public JudgeInfo(
        EJudge judge,
        bool isHit,
        Sprite noteSprite,
        Color noteColor,
        Quaternion noteRotation,
        Vector3 noteScale)

    {
        Judge = judge;
        IsHit = isHit;
        NoteSprite = noteSprite;
        NoteColor = noteColor;
        NoteRotation = noteRotation;
        NoteScale = noteScale;
    }
}
