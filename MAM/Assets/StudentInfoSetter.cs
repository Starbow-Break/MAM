using UnityEngine;

public class StudentInfoSetter : MonoBehaviour
{
    [SerializeField] StudentInfoUpdater _updater;

    public void Initialize()
    {
        _updater.SetActive(false);
    }
}
