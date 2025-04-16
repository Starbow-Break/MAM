using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LunchRestaurantButtonSetter : MonoBehaviour
{
    [FormerlySerializedAs("_studentButtonUpdater")]
    [Header("Updater")]
    [SerializeField] private RestaurantButtonUpdater _restaurantButtonUpdater;
    
    [Header("Instantiate")]
    [SerializeField] private Transform _parent;

    private List<RestaurantButtonUpdater> _updaters = new();
    private RadioButtonGroup _restaurantsGroup;
    public RadioButtonGroup RestaurantGroup
    {
        get { return _restaurantsGroup; }
    }
    
    public void Initialize(List<Restaurant> restaurants)
    {
        SImpleRadioButton[] buttons = new SImpleRadioButton[restaurants.Count];
        
        foreach (var restaurant in restaurants)
        {
            RestaurantButtonUpdater newUpdater = Instantiate(_restaurantButtonUpdater, _parent);
            newUpdater.SetIcon(restaurant.Icon);
            newUpdater.SetName(restaurant.Name);
            _updaters.Add(newUpdater);
        }

        for (int i = 0; i < _updaters.Count; i++)
        {
            SImpleRadioButton button = _updaters[i].GetComponent<SImpleRadioButton>();
            if (button != null)
            {
                buttons[i] = button;
            }
        }
        _restaurantsGroup = new RadioButtonGroup(buttons);
    }
}
