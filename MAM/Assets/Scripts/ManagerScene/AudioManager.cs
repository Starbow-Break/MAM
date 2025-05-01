using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudioSource = null;
    
    public void PlayBGM()
    {
        _bgmAudioSource.Play();
    }

    public void PauseBGM()
    {
        _bgmAudioSource.Pause();
    }

    public void ResumeBGM()
    {
        _bgmAudioSource.UnPause();
    }
}
