using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelfStudySceneCharacterSetter : MonoBehaviour
{
    [SerializeField] private Vector2 _areaCenter = new Vector2(0.5f, -1f);
    [SerializeField] private  Vector2 _areaSize = new Vector2(19f, 10f);
    
    private List<StudentCharacter> _characters = new List<StudentCharacter>();
 
    private void Start()
    {

        foreach (string id in GameManager.StudentManager.GetStudentIds())
        {
            StudentCharacter character = GameManager.StudentManager.GetStudentCharacter(id);
            character.transform.position = GetRandomTileWorldPosition();
            character.transform.SetParent(transform);
            character.InitializeClickDetecter();
            character.gameObject.SetActive(true);

            _characters.Add(character);
        }
    }
    
    private Vector3 GetRandomTileWorldPosition()
    {
        float x = Random.Range(_areaCenter.x - _areaSize.x / 2f, _areaCenter.x + _areaSize.x / 2f);
        float y = Random.Range(_areaCenter.y - _areaSize.y / 2f, _areaCenter.y + _areaSize.y / 2f);
        return new Vector2(x, y);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_areaCenter, _areaSize);
        Gizmos.color = Color.white;
    }
    
}
