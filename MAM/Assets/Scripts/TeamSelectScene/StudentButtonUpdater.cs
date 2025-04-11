using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudentButtonUpdater : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void AddOnHoverEventListener(UnityAction action)
    {
        GetComponent<StudentButton>().OnHover += action;
    }
    
    public void AddOnUnHoverEventListener(UnityAction action)
    {
        GetComponent<StudentButton>().OnUnHover += action;
    }
}
