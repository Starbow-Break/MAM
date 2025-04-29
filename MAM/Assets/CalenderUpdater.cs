using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalenderUpdater : MonoBehaviour
{
    [SerializeField] private RectTransform _teacher;
    [SerializeField] private List<RectTransform> _squareRects;
    [SerializeField] private float moveBeforeDelay = 1f;
    [SerializeField] private float moveAfterDelay = 1f;

    public bool IsMoving { get; private set; } = false;

    public UnityAction OnMoveFinished;

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void OnDisable()
    {
        OnMoveFinished = null;
    }

    public void SetTeacherPosition(int index)
    {
        RectTransform newParent = _squareRects[index];
        _teacher.SetParent(newParent);
        _teacher.anchoredPosition = Vector3.zero;
    }
    
    public void MoveTeacher(int targetIndex, float speed = 300f)
    {
        RectTransform target = _squareRects[targetIndex];
        StartCoroutine(MoveFlow(target, speed));
    }
    
    private IEnumerator MoveFlow(RectTransform target, float speed)
    {
        yield return new WaitForSeconds(moveBeforeDelay);
        
        _teacher.SetParent(target);
        _teacher.GetComponent<Animator>().SetBool("Walk", true);
        
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
        _teacher.GetComponent<Animator>().SetBool("Walk", false);
        
        yield return new WaitForSeconds(moveAfterDelay);
        OnMoveFinished?.Invoke();
    }
}
