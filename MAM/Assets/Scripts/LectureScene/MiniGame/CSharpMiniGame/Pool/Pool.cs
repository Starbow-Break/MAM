using UnityEngine;
using UnityEngine.Pool;

[DefaultExecutionOrder(-2000)]
public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T prefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;
    [SerializeField] private bool _collectionCheck = false;

    private IObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(CreateObject, OnGet, OnRelease, Destroy, 
            _collectionCheck, _defaultCapacity, _maxSize);
    }

    #region Create Object
    private T CreateObject()
    {
        T obj = Instantiate(prefab);
        return obj;
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

    #region Destroy Object
    private void Destroy(T obj)
    {
        Destroy(obj.gameObject);
    }
    #endregion
}
