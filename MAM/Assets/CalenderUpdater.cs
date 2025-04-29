using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CalenderUpdater : MonoBehaviour
{
    [SerializeField] private RectTransform _teacher;
    [SerializeField] private List<RectTransform> _squareRects;
    [SerializeField] private float moveBeforeDelay = 1f;
    [SerializeField] private float moveAfterDelay = 1f;

    public bool IsMoving { get; private set; } = false;

    public UnityAction OnMoveFinished;

    public void Initialize()
    {
        int currentProject = GameManager.FlowManager.CurrentProject;
        int currentDay = GameManager.FlowManager.CurrentDay;
        int currentIndex = GetRectIndex(currentProject, currentDay);
        
        RectTransform target = _squareRects[currentIndex];
        _teacher.SetParent(target);
        _teacher.anchoredPosition = Vector3.zero;
    }

    public void Start()
    {
        Initialize();
    }

    public void OnDisable()
    {
        OnMoveFinished = null;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !IsMoving)
        {
            IsMoving = true;
            MoveNext();
        }
    }

    public void MoveNext()
    {
        int currentProject = GameManager.FlowManager.CurrentProject;
        int currentDay = GameManager.FlowManager.CurrentDay;
        int currentIndex = GetRectIndex(currentProject, currentDay);
        
        MoveTeacher(_squareRects[currentIndex + 1], 300f);
    }
    
    private void MoveTeacher(RectTransform target, float speed)
    {
        StartCoroutine(MoveFlow(target, speed));
    }
    
    private IEnumerator MoveFlow(RectTransform target, float speed)
    {
        yield return new WaitForSeconds(moveBeforeDelay);
        
        _teacher.SetParent(target);
        
        float time = _teacher.anchoredPosition.magnitude / speed;
        Vector3 startPosition = _teacher.anchoredPosition;
        float currentTime = 0f;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            Debug.Log($"{currentTime} - {time}");
            float normalizedTime = Mathf.Clamp01(currentTime / time);
            _teacher.anchoredPosition = Vector3.Lerp(startPosition, Vector3.zero, normalizedTime);
            yield return null;
        }
        IsMoving = false;
        
        yield return new WaitForSeconds(moveAfterDelay);
        OnMoveFinished?.Invoke();
    }

    public int GetRectIndex(int project, int day)
    {
        return (project - 1) * 4 + (day - 1);
    }
}
