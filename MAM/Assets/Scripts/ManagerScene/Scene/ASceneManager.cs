using UnityEngine;

[DefaultExecutionOrder(-900)]
public class ASceneManager : MonoBehaviour
{
    public static ASceneManager Instance;
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

}
