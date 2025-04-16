using TMPro;
using UnityEngine;

public class StudentSelectedInfoUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _infoText;

    public void SetText(int selected, int maximum)
    {
        _infoText.text = $"선택된 학생 수 : {selected} / {maximum}";
    }
}
