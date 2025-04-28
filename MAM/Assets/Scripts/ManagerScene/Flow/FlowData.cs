using UnityEngine;

[CreateAssetMenu(fileName = "New Flow Data", menuName = "Scriptable Object/Flow Data")]
public class FlowData : ScriptableObject
{
    public int TotalDaysInProject = 3;
    public float[] ProjectProgressGoals = null;
    
    public int TotalProjectCount => ProjectProgressGoals.Length;
}
