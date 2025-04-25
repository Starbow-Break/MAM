using UnityEngine;

public class JudgeInfo
{
    public EJudge Judge;
    public Sprite NoteSprite;
    public Color NoteColor;
    public Quaternion NoteRotation;
    public Vector3 NoteScale;   

    public JudgeInfo(
        EJudge judge,
        Sprite noteSprite,
        Color noteColor,
        Quaternion noteRotation,
        Vector3 noteScale)

    {
        Judge = judge;
        NoteSprite = noteSprite;
        NoteColor = noteColor;
        NoteRotation = noteRotation;
        NoteScale = noteScale;
    }
}
