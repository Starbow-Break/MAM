using UnityEngine;
using UnityEngine.Events;

public class CSharpMiniGameInput : MonoBehaviour
{
    [SerializeField] private KeyCode hitKey = KeyCode.Space;

    public UnityAction OnKeyDown;

    private void Update()
    {
        if (Input.GetKeyDown(hitKey)) OnKeyDown?.Invoke();
    }
}