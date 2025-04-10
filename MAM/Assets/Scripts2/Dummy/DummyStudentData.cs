using UnityEngine;

[CreateAssetMenu(fileName = "StudentDummyData", menuName = "Scriptable Object/StudentDummyData", order = int.MaxValue)]
public class DummyStudentData : ScriptableObject
{
    [field: SerializeField]
    public Color Color { get; private set; }    // 색
    [field: SerializeField]
    public string Name { get; private set; }    // 이름
}
