using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    private ESceneIndex _currentScene = ESceneIndex.Title;
    private List<AsyncOperation> _loadingOperations = new List<AsyncOperation>();

    private static readonly float _fadeDuration = 0.3f;
    
    public ESceneIndex CurrentScene{get{return _currentScene;}}
    
    public void LoadTitle()
    {
        SceneManager.LoadSceneAsync((int)ESceneIndex.Title, LoadSceneMode.Additive);
        _currentScene = ESceneIndex.Title;
    }

    public void LoadScene(ESceneIndex scene)
    {
        GameManager.HUDManager.FadeOut(_fadeDuration, () =>
        {
            _loadingOperations.Add(SceneManager.UnloadSceneAsync((int)_currentScene));
            _loadingOperations.Add(SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive));
            StartCoroutine(GetSceneLoading(scene));
        });
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
        
        yield return new WaitForSeconds(_fadeDuration);
        
        GameManager.HUDManager.FadeIn(_fadeDuration);
        _currentScene = scene;
    }

    
}
