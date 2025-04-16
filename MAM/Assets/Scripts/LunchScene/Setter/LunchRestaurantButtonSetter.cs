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
    
    public void Initialize(List<Restaurant> restaurants)
    {
        foreach (var restaurant in restaurants)
        {
            RestaurantButtonUpdater _newUpdater = Instantiate(_restaurantButtonUpdater, _parent);
            _newUpdater.SetIcon(restaurant.Icon);
            _newUpdater.SetName(restaurant.Name);
            _updaters.Add(_newUpdater);
        }
    }
}
