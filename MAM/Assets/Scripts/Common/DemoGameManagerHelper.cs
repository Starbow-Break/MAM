using UnityEngine;
using UnityEngine.EventSystems;

public class DemoGameManagerHelper : MonoBehaviour
{
    private void Start()
    {
        SetEventSystem();
    }

    //이벤트시스템 생성
    private void SetEventSystem()
    {       
        if (FindObjectOfType<EventSystem>() == null)
        {
            var obj = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }
}
