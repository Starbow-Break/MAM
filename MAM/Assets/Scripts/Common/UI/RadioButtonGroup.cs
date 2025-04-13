using UnityEngine;
using UnityEngine.UI;

public class RadioButtonGroup
{
    private readonly SImpleRadioButton[] _buttons = null;

    public SImpleRadioButton SelectedButton { get; private set; } = null;
    public int SelectedIndex { get; private set; } = -1;  //-1 선택안됨
    
    public RadioButtonGroup(SImpleRadioButton[] buttons)
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
            return;
        }
        
        //다른거누를때
        if(SelectedButton != null)
            SelectedButton.PlayDeSelectAnimation();
        
        SelectedButton = _buttons[selectedIndex];
        SelectedIndex = selectedIndex;
        SelectedButton.PlaySelectAnimation();
    }
}
