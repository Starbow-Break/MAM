using UnityEngine;

public class LunchStudentInfoSetter : MonoBehaviour
{
    [SerializeField] StudentInfoUpdater _studentInfoUpdater;
    
    public void Initialize()
    {
        _studentInfoUpdater.SetActive(false);
    }
}
