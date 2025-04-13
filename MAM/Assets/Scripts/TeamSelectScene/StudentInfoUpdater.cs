
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudentInfoUpdater : MonoBehaviour
{
    private readonly string CarrotText = "당근";
    private readonly string WhipText = "채찍";

    [Header("Student")]
    [SerializeField] private Image _icon;   // 학생 아이콘
    [SerializeField] private TextMeshProUGUI _name; // 학생 이름

    [Header("Status")]
    [SerializeField] private TextMeshProUGUI _unity;    // 유니티 스텟
    [SerializeField] private TextMeshProUGUI _cSharp;   // C# 스텟
    [SerializeField] private TextMeshProUGUI _mbti; // MBTI
    [SerializeField] private TextMeshProUGUI _favRestaurant;    // 선호 식당
    [SerializeField] private TextMeshProUGUI _affinity; // 기호

    // 활성화/비활성화
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    // 인자로 받은 학생의 정보로 변경
    public void SetStudent(Student student)
    {
        _icon.sprite = student.Icon;
        _name.text = student.Name;
        _unity.text = student.UnitySkill.ToString();
        _cSharp.text = student.CSharpSkill.ToString();
        _mbti.text = student.MBTI;
        _favRestaurant.text = student.FavRestaurant;
        _affinity.text = student.AffinityType == EAffinityType.Carrot ? CarrotText : WhipText;
    }
}
