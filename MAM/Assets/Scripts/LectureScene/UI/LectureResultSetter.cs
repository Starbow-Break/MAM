using UnityEngine;

public class LectureResultSetter : MonoBehaviour
{
    [SerializeField] private LectureResultUpdater _updater = null;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        
    }

    public void ShowPopup()
    {
        _updater.gameObject.SetActive(true);
    }
}
