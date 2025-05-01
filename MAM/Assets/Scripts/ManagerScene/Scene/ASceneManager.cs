using System;
using UnityEngine;

[DefaultExecutionOrder(-900)]
public class ASceneManager<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected string _sceneName = string.Empty;

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    Debug.LogError($" {typeof(T).Name} 못찾음");
                }
            }
            return _instance;
        }
    }
    
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        
        GameManager.HUDManager.SetSceneName(_sceneName);
    }
    
}
