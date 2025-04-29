using System;
using System.Collections.Generic;
using UnityEngine;

public class CSharpMiniGameRiderUpdater : MonoBehaviour
{
    [SerializeField] private RiderCodeNavigator _navigator;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _cursor;
    
    private readonly float Unit = 0.125f;
    private readonly int WindowHeightUnit = 16;
    private readonly int ReleaseUnit = 20;

    private int _cursorPositionUnit = 0;

    private Queue<SpriteRenderer> rendererQueue = new();
        
    private void OnEnable()
    {
        CSharpMiniGame.Controller.OnJudge += JudgeInfo => AddCode(JudgeInfo.Judge);
    }
    
    private void OnDisable()
    {
        CSharpMiniGame.Controller.OnJudge -= JudgeInfo => AddCode(JudgeInfo.Judge);
    }

    private void AddCode(EJudge judge)
    {
        SpriteRenderer codeRenderer = _navigator.GetCodeRenderer(judge);
        GameObject codeObj = codeRenderer.gameObject;
        AttachCode(codeObj, _parent, _cursor);
        rendererQueue.Enqueue(codeRenderer);
        _cursor.localPosition += Unit * Vector3.down;
        _cursorPositionUnit++;

        if (_cursorPositionUnit > WindowHeightUnit)
        {
            int unit = _cursorPositionUnit - WindowHeightUnit;
            _parent.localPosition += unit * Unit * Vector3.up;
            _cursorPositionUnit -= unit;
        }

        while (rendererQueue.Count > 0)
        {
            Vector3 localPosition = rendererQueue.Peek().transform.localPosition;
            if (localPosition.y - _cursor.localPosition.y > ReleaseUnit * Unit)
            {
                SpriteRenderer sr = rendererQueue.Dequeue();
                string prefabName = sr.gameObject.name.Substring(0, sr.gameObject.name.Length - 7);
                CodeSpritePoolManager.Instance.Release(prefabName, sr);
            }
            else
            {
                break;
            }
        }
    }

    private void AttachCode(GameObject codeObj, Transform parent, Transform target)
    {
        codeObj.transform.SetParent(parent);
        codeObj.transform.localPosition = target.localPosition;
        codeObj.transform.localRotation = target.localRotation;
        codeObj.transform.localScale = target.localScale;
    }
}
