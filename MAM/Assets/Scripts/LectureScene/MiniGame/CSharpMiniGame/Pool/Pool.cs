using UnityEngine;
using UnityEngine.Pool;

[DefaultExecutionOrder(-2000)]
public class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;
    [SerializeField] private bool _collectionCheck;

    private IObjectPool<T> _pool;

    public string PrefabName => _prefab.name;

    private void Awake()
    {
        _pool = new ObjectPool<T>(CreateObject, OnGet, OnRelease, Destroy,
            _collectionCheck, _defaultCapacity, _maxSize);
    }

    #region Create Object

    private T CreateObject()
    {
        var obj = Instantiate(_prefab);
        return obj;
    }

    #endregion

    #region Destroy Object

    private void Destroy(T obj)
    {
        Destroy(obj.gameObject);
    }

    #endregion

    #region Get

    public virtual T Get()
    {
        return _pool.Get();
    }

    private void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    #endregion

    #region Release

    public virtual void Release(T obj)
    {
        _pool.Release(obj);
    }

    private void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    #endregion
}