using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantButtonUpdater : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;

    public void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }

    public void SetName(string name)
    {
        _name.text = name;
    }
}
