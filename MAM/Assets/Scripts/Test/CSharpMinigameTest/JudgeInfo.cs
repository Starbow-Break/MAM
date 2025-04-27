using UnityEngine;

public class JudgeInfo
{
    public EJudge Judge;
    public ENoteType NoteType;
    public Sprite NoteSprite;
    public Color NoteColor;
    public Quaternion NoteRotation;
    public Vector3 NoteScale;   

    public JudgeInfo(
        EJudge judge,
        ENoteType noteType,
        Sprite noteSprite,
        Color noteColor,
        Quaternion noteRotation,
        Vector3 noteScale)

    {
        Judge = judge;
        NoteType = noteType;
        NoteSprite = noteSprite;
        NoteColor = noteColor;
        NoteRotation = noteRotation;
        NoteScale = noteScale;
    }
}
