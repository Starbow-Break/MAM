using System.Collections.Generic;
using UnityEngine;

public class LunchSceneManager : ASceneManager<LunchSceneManager>
{
    public enum EUIObjectType
    {
        Select_Lunch,
        Raise_Intimacy
    }

    [System.Serializable]
    public struct UIObjectData
    {
        [field: SerializeField]
        public EUIObjectType uiType { get; private set; }
        [field: SerializeField]
        public GameObject uiObject { get; private set; }
    }
    
    [Header("Controller")]
    [SerializeField] private LunchSceneController _controller;
    
    [Header("Setter")]
    [SerializeField] private LunchRestaurantButtonSetter _restaurantButtonSetter;
    [SerializeField] private LunchStudentButtonSetter _studentButtonSetter;
    [SerializeField] private LunchStudentInfoSetter _studentinfoSetter;
    [SerializeField] private LunchSubmitButtonSetter _submitButtonSetter;
    [SerializeField] private LunchStudentSelectedInfoSetter _studentSelectedInfoSetter;
    [SerializeField] private LunchRaiseIntimacySetter _raiseIntimacySetter;

    [Header("UI Pages")] [SerializeField] private List<UIObjectData> _uiDatas;
    
    public static LunchSceneController Controller => Instance._controller;
    public static LunchRaiseIntimacySetter RaiseIntimacySetter => Instance._raiseIntimacySetter;
    
    public void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        // 식당 묵록 초기화
        InitializeRestaurantButtonUI();
        // 학생 묵록 초기화
        InitializeStudentButtonUI();
        // 학생 정보 초기화
        InitializeStudentInfoUI();
        // 확인 버튼 초기화
        InitializeSubmitButton();
        // 학생 선택 상태 초기화
        InitializeStudentSelectedInfoUI();
        // 친밀도 화면 초기화
        InitializeRaisedIntimacyUI();
        
        SetUiObjects(EUIObjectType.Select_Lunch);
    }

    private void InitializeRestaurantButtonUI()
    {
        List<Restaurant> restaurants = GameManager.RestaurantTable.GetRestaurants();
        _restaurantButtonSetter.Initialize(restaurants);
    }
    
    private void InitializeStudentButtonUI()
    {
        List<Student> students = GameManager.StudentManager.GetStudents();
        _studentButtonSetter.Initialize(students);
    }

    private void InitializeStudentInfoUI()
    {
        _studentinfoSetter.Initialize();
    }

    private void InitializeSubmitButton()
    {
        _submitButtonSetter.Initialize();
    }

    private void InitializeStudentSelectedInfoUI()
    {
        _studentSelectedInfoSetter.Initialize();
    }
    
    private void InitializeRaisedIntimacyUI()
    {
        _raiseIntimacySetter.Initialize(_controller.MaxSelectedStudent);
    }

    public void SetUiObjects(EUIObjectType uiType)
    {
        foreach (var uiData in _uiDatas)
        {
            uiData.uiObject.SetActive(uiData.uiType == uiType);
        }
    }
}
