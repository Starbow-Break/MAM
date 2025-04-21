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
    
    public void Initialize(List<Restaurant> restaurants)
    {
        SimpleRadioButton[] buttons = new SimpleRadioButton[restaurants.Count];
        
        foreach (var restaurant in restaurants)
        {
            RestaurantButtonUpdater newUpdater = Instantiate(_restaurantButtonUpdater, _parent);
            newUpdater.SetRestaurant(restaurant);
            _updaters.Add(newUpdater);
        }

        for (int i = 0; i < _updaters.Count; i++)
        {
            SimpleRadioButton button = _updaters[i].RadioButton;
            if (button != null)
            {
                buttons[i] = button;
            }
        }
        _restaurantsGroup = new RadioButtonGroup(buttons);
        _restaurantsGroup.OnValueChanged += (index) => UpdateController(index);
    }

    private void UpdateController(int index)
    {
        var controller = LunchSceneManager.Controller;
        controller.SelectRestaurant(index == -1 ? null : _updaters[index].Restaurant);
    }
}
