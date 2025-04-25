using UnityEngine;

public class JudgeInfo
{
    public EJudge Judge;
    public Sprite NoteSprite;
    public Quaternion NoteRotate;
    public Vector3 NoteScale;

    public JudgeInfo(
        EJudge judge,
        Sprite noteSprite,
        Quaternion noteRotate,
        Vector3 noteScale)
    {
        Judge = judge;
        NoteSprite = noteSprite;
        NoteRotate = noteRotate;
        NoteScale = noteScale;
    }
}
