using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalenderUpdater : MonoBehaviour
{
    private readonly int WalkHash = Animator.StringToHash("Walk");
    private readonly int ProjectPerDay = 4;
    private readonly int TotalProject = 3;

    [SerializeField] private RectTransform _teacher;
    [SerializeField] private List<RectTransform> _squareRects;
    [SerializeField] private List<RectTransform> _endPointRect;
    [SerializeField] private float moveBeforeDelay = 1f;
    [SerializeField] private float moveAfterDelay = 1f;
    [SerializeField] private float moveSpeed = 300f;

    private Animator _teacherAnim;
    private Tuple<int, int> _teacherPosition = new Tuple<int, int>(0, 0);

    public UnityAction OnMoveFinished;

    public void Awake()
    {
        _teacherAnim = _teacher.GetComponent<Animator>();
    }

    public void OnDisable()
    {
        OnMoveFinished = null;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    private void SetTeacherPosition(RectTransform rect)
    {
        _teacher.SetParent(rect);
        _teacher.anchoredPosition = Vector3.zero;
    }

    public void SetTeacherPosition(int project, int day)
    {
        int index = GetRectIndex(project, day);
        RectTransform newParent = _squareRects[index];
        SetTeacherPosition(newParent);
        _teacherPosition = new Tuple<int, int>(project, day);
    }
    
    public void MoveTeacher(int project, int day)
    {
        StartCoroutine(MoveTeacherSequence(project, day));
    }

    private IEnumerator MoveTeacherSequence(int project, int day)
    {
        yield return new WaitForSeconds(moveBeforeDelay);

        int index = GetRectIndex(project, day);
        RectTransform target = _squareRects[index];

        int curProj = _teacherPosition.Item1;
        if(curProj < project)
        {
            RectTransform left = _endPointRect[2 * (project - 1)];
            RectTransform right = _endPointRect[2 * (_teacherPosition.Item1 - 1) + 1];
            yield return MoveSequence(right);
            SetTeacherPosition(left);
            yield return MoveSequence(target);
        }
        else if(curProj > project)
        {
            RectTransform left = _endPointRect[2 * (_teacherPosition.Item1 - 1)];
            RectTransform right = _endPointRect[2 * (project - 1) + 1];
            yield return MoveSequence(left);
            SetTeacherPosition(right);
            yield return MoveSequence(target);
        }
        else {
            yield return MoveSequence(target);
        }

        yield return new WaitForSeconds(moveAfterDelay);

        _teacherPosition = new Tuple<int, int>(project, day);
        OnMoveFinished?.Invoke();
    }
    
    private IEnumerator MoveSequence(RectTransform target)
    {
        _teacher.SetParent(target);
        _teacherAnim.SetBool(WalkHash, true);
        
        float time = _teacher.anchoredPosition.magnitude / moveSpeed;
        Vector3 startPosition = _teacher.anchoredPosition;
        float currentTime = 0f;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(currentTime / time);
            _teacher.anchoredPosition = Vector3.Lerp(startPosition, Vector3.zero, normalizedTime);
            yield return null;
        }
        _teacherAnim.SetBool(WalkHash, false);
    }

    public int GetRectIndex(int project, int day)
    {
        return (project - 1) * ProjectPerDay + (day - 1);
    }
}
