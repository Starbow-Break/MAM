using UnityEngine;

public class TeamSelectStudentInfoSetter : MonoBehaviour
{
    [SerializeField] StudentInfoUpdater _updater;

    public void Initialize()
    {
        _updater.SetActive(false);
    }
}
