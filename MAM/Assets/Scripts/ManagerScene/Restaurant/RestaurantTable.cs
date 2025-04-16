using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Restaurant
{
    public string ID;
    
    public string Name;
    public Sprite Icon;
}


[CreateAssetMenu(fileName = "RestaurantTable", menuName = "Scriptable Object/RestaurantTable")]
public class RestaurantTable : ScriptableObject
{
#if UNITY_EDITOR
    public string URL_ID = "1geUI-yXY5iO3cqlfqMH_vRGQ5TQjIyalk7tYtBUhAVA";
    public string URL_SHEET = "1049994877";
#endif
    
    public List<Restaurant> RestaurantList = new List<Restaurant>();
    
    public Restaurant GetRestaurant(string ID)
    {
        return RestaurantList.Find(x => x.ID == ID);
    }

    public List<Restaurant> GetRestaurants()
    {
        return RestaurantList;
    }

    public int GetTotalRestaurantCount()
    {
        return RestaurantList.Count;
    }
}

