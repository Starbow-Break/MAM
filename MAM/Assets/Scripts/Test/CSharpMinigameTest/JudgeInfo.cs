using UnityEngine;

public class JudgeInfo
{
    public EJudge Judge;
    public ENoteType NoteType;
    public bool IsHit;
    public Sprite NoteSprite;
    public Color NoteColor;
    public Quaternion NoteRotation;
    public Vector3 NoteScale;   

    public JudgeInfo(
        EJudge judge,
        ENoteType noteType,
        bool isHit,
        Sprite noteSprite,
        Color noteColor,
        Quaternion noteRotation,
        Vector3 noteScale)

    {
        Judge = judge;
        NoteType = noteType;
        IsHit = isHit;
        NoteSprite = noteSprite;
        NoteColor = noteColor;
        NoteRotation = noteRotation;
        NoteScale = noteScale;
    }
}
