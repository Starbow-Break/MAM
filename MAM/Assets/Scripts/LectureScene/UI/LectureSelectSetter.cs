using UnityEngine;

public class LectureSelectSetter : MonoBehaviour
{
    [SerializeField] private LectureSelectUpdater _updater;
    private RadioButtonGroup _lectureLevelGroup;

    private RadioButtonGroup _lectureTypeGroup;

    private void Start()
    {
        _lectureTypeGroup = new RadioButtonGroup(_updater.LectureButtons);
        _lectureLevelGroup = new RadioButtonGroup(_updater.LevelButtons);

        _updater.StartButton.onClick.AddListener(OnClickStartButton);
        _updater.gameObject.SetActive(true);
    }

    private void OnClickStartButton()
    {
        if (_lectureLevelGroup.SelectedIndex == -1)
            return;
        if (_lectureTypeGroup.SelectedIndex == -1)
            return;

        _updater.gameObject.SetActive(false);

        var miniGameType = (ESkillType)_lectureTypeGroup.SelectedIndex;
        LectureSceneManager.MiniGameController.PlayMiniGame(miniGameType, _lectureLevelGroup.SelectedIndex + 1);
    }
}