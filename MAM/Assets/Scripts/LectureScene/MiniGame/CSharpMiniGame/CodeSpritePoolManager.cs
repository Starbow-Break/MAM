using System.Collections.Generic;
using UnityEngine;

public class CodeSpritePoolManager : MonoBehaviour
{
    [SerializeField] private List<SpriteRendererPool> _poolList;

    private Dictionary<string, SpriteRendererPool> _pools = new();

    public static CodeSpritePoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        } 
    }

    private void Start()
    {
        foreach(var pool in _poolList)
        {
            _pools.Add(pool.PrefabName, pool);
        }
    }

    public SpriteRenderer Spawn(string name, Vector3 position, Quaternion rotation, Transform parent)
    {
        SpriteRenderer sr = _pools[name].Get();
        sr.transform.position = position;
        sr.transform.rotation = rotation;
        sr.transform.SetParent(parent, worldPositionStays: true);

        return sr;
    }

    public void Release(string name, SpriteRenderer sr)
    {
        _pools[name].Release(sr);
    }
}
