using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestaurantButtonUpdater : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    
    public Restaurant Restaurant { get; private set; }
    
    public void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }

    public void SetName(string name)
    {
        _name.text = name;
    }
    
    public void SetRestaurant(Restaurant restaurant)
    {
        Restaurant = restaurant;
        SetIcon(restaurant.Icon);
        SetName(restaurant.Name);
    }
}