using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RadioButtonGroup
{
    private readonly SimpleRadioButton[] _buttons = null;

    public SimpleRadioButton SelectedButton { get; private set; } = null;
    public int SelectedIndex { get; private set; } = -1;  //-1 선택안됨

    public UnityAction<int> OnValueChanged;    // 선택된 값이 바뀔 대 발생하는 이벤트
        
    public RadioButtonGroup(SimpleRadioButton[] buttons)
    {
        _buttons = buttons;

        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;
            _buttons[i].ActOnClick += () =>
            {
                SetSelectedButton(index);
            };
        }
    }

    private void SetSelectedButton(int selectedIndex)
    {
        //눌렀던거 다시누를때
        if (SelectedButton == _buttons[selectedIndex])
        {
            SelectedButton.PlayDeSelectAnimation();
            SelectedButton = null;
            SelectedIndex = -1;
        }
        else
        {
            //다른거누를때
            if(SelectedButton != null)
                SelectedButton.PlayDeSelectAnimation();
        
            SelectedButton = _buttons[selectedIndex];
            SelectedIndex = selectedIndex;
            SelectedButton.PlaySelectAnimation();
        }

        OnValueChanged?.Invoke(SelectedIndex);
    }
}
