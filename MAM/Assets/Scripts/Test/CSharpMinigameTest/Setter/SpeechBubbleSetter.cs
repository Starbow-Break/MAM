using System.Collections;
using UnityEngine;

public class SpeechBubbleSetter : MonoBehaviour
{
    [SerializeField] SpeechBubbleUpdater _updater;

    public void Initialize()
    {
        _updater.SetActive(false);
    }
    
    public void Show(string text, float time)
    {
        StartCoroutine(ShowSequence(text, time));
    }

    private IEnumerator ShowSequence(string text, float time)
    {
        _updater.SetActive(true);
        _updater.SetText(text);

        yield return new WaitForSeconds(time);

        _updater.SetActive(false);
    }
}
