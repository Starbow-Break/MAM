using System.Collections;
using UnityEngine;

public class IfNoteUpdater : ANoteUpdater
{
    [SerializeField] private SpriteRenderer _renderer;

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
    
    protected override IEnumerator ActSequence()
    {
        yield return null;
    }
}
