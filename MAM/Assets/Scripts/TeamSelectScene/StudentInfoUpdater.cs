using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudentInfoUpdater : MonoBehaviour
{
    [Header("Student")]
    [SerializeField] private Image _icon;   // 학생 아이콘
    [SerializeField] private TextMeshProUGUI _name; // 학생 이름

    [Header("Status")]
    [SerializeField] private TextMeshProUGUI _unity;    // 유니티 스텟
    [SerializeField] private TextMeshProUGUI _cSharp;   // C# 스텟
    [SerializeField] private TextMeshProUGUI _mbti; // MBTI
    [SerializeField] private TextMeshProUGUI _favRestaurant;    // 선호 식당
    [SerializeField] private TextMeshProUGUI _affinity; // 기호
    [SerializeField] private TextMeshProUGUI _intimacy; // 친밀도
    [SerializeField] private TextMeshProUGUI _motivation;   // 의욕

    // 활성화/비활성화
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    // 인자로 받은 학생의 정보로 변경
    public void SetStudent(Student student)
    {
        if(student != null)
        {
            _icon.sprite = student.Icon;
            _name.text = student.Name;
            _unity.text = Mathf.FloorToInt(student.UnitySkill).ToString();
            _cSharp.text = Mathf.FloorToInt(student.CSharpSkill).ToString();
            _intimacy.text = Mathf.FloorToInt(student.Intimacy).ToString();
            _mbti.text = StudentInfoDisplayer.GetMBTI(student);
            _favRestaurant.text = StudentInfoDisplayer.GetMBTI(student);
            _affinity.text = StudentInfoDisplayer.GetAffinityType(student);
            _motivation.text = StudentInfoDisplayer.GetMotivation(student);
        }
    }
}
