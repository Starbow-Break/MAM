using UnityEngine;

[System.Serializable]
public class Team 
{
    public Student Member1 { get; set; }
    public Student Member2 { get; set; }
    public int TeamNumber { get; set; }
    public float ProjectProgress { get; set; }
    public bool GotHelped { get; set; } = false;
}
