using System;
using UnityEngine;

public class CSharpMiniGameRiderUpdater : MonoBehaviour
{
    [SerializeField] private RiderCodeNavigator _navigator;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _cursor;
    
    private readonly float Unit = 0.125f;
    private readonly int WindowHeightUnit = 16;

    private int _cursorPositionUnit = 0;
        
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
        GameObject codeObj = _navigator.GetCode(judge);
        codeObj.transform.SetParent(_parent);
        codeObj.transform.localPosition = _cursor.localPosition;
        codeObj.transform.localRotation = _cursor.localRotation;
        codeObj.transform.localScale = _cursor.localScale;
        _cursor.localPosition += Unit * Vector3.down;
        _cursorPositionUnit++;

        if (_cursorPositionUnit > WindowHeightUnit)
        {
            int q = _cursorPositionUnit - WindowHeightUnit;
            _parent.localPosition += q * Unit * Vector3.up;
            _cursorPositionUnit -= q;
        }
    }
}
