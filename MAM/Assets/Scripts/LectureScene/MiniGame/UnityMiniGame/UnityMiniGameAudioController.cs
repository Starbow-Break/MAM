using UnityEngine;

public class UnityMiniGameAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudioSource = null;
    [SerializeField] private AudioSource _buttonAudioSource = null;
    [SerializeField] private AudioSource _effectAudioSource = null;
    
    [SerializeField] private AudioClip _buttonPressClip = null;
    [SerializeField] private AudioClip _correctSetClip = null;
    [SerializeField] private AudioClip _wrongSetClip = null;

    public void PlayBGM()
    {
        _bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        _bgmAudioSource.Stop();
    }
    public void PlayButtonPressSound()
    {
        _buttonAudioSource.Stop();
        _buttonAudioSource.PlayOneShot(_buttonPressClip);
    }

    public void PlayCorrectSetSound()
    {
        _effectAudioSource.Stop();
        _effectAudioSource.PlayOneShot(_correctSetClip);
    }

    public void PlayWrongSetSound()
    {
        _effectAudioSource.Stop();
        _effectAudioSource.PlayOneShot(_wrongSetClip);
    }
}
