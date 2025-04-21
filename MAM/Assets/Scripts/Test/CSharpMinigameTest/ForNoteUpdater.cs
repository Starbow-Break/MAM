using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ForNoteUpdater : ANoteUpdater
{
    [SerializeField] TextMeshPro _countText;
    
    private int _count = 3; // 박자 

    protected override IEnumerator ActSequence()
    {
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            SetCount(_count - 1);
        }
        
        Destroy(gameObject);
    }

    public void SetCount(int count)
    {
        _count = count;
        _countText.text = count.ToString();
    }
}
