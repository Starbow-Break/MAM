using System.Collections.Generic;
using UnityEngine;

public class LunchSceneManager : ASceneManager<LunchSceneManager>
{
    [SerializeField] private LunchRestaurantButtonSetter _restaurantButtonSetter;
    [SerializeField] private LunchStudentButtonSetter _studentButtonSetter;
    [SerializeField] private LunchStudentInfoSetter _studentinfoSetter;
    [SerializeField] private LunchSubmitButtonSetter _submitButtonSetter;
    [SerializeField] private LunchStudentSelectedInfoSetter _studentSelectedInfoSetter;
    
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
}
