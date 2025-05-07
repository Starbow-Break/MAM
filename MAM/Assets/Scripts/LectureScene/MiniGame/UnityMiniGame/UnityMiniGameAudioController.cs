using UnityEngine;

public class UnityMiniGameAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _buttonAudioSource;
    [SerializeField] private AudioSource _effectAudioSource;

    [SerializeField] private AudioClip _buttonPressClip;
    [SerializeField] private AudioClip _correctSetClip;
    [SerializeField] private AudioClip _wrongSetClip;

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