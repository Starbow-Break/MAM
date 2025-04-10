using System.Collections.Generic;
using UnityEngine;

public class DummyStudentDataManager : MonoBehaviour
{
    [SerializeField] private List<DummyStudentData> _datas;
    
    public static DummyStudentDataManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public List<DummyStudentData> GetStudentDatas()
    {
        return _datas;
    }
}
