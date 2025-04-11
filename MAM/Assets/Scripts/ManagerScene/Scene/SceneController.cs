using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen = null;

    private ESceneIndex _currentScene = ESceneIndex.Title;
    private List<AsyncOperation> _loadingOperations = new List<AsyncOperation>();
    
    public ESceneIndex CurrentScene{get{return _currentScene;}}
    
    public void LoadTitle()
    {
        SceneManager.LoadSceneAsync((int)ESceneIndex.Title, LoadSceneMode.Additive);
        _currentScene = ESceneIndex.Title;
    }

    public void LoadScene(ESceneIndex scene)
    {
        _loadingScreen.SetActive(true);
        _loadingOperations.Add(SceneManager.UnloadSceneAsync((int)_currentScene));
        _loadingOperations.Add(SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoading(scene));
    }

    private IEnumerator GetSceneLoading(ESceneIndex scene)
    {
        for (int i = 0; i < _loadingOperations.Count; i++)
        {
            while (!_loadingOperations[i].isDone)
            {
                yield return null;
            }
        }
        
        _currentScene = scene;
        _loadingScreen.SetActive(false);
    }

    
}
