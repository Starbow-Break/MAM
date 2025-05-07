using UnityEngine;

public class CSharpMiniGameSFXAudio : MonoBehaviour
{
    [Header("SFX")] [SerializeField] private AudioSource _noteSpawn;

    [SerializeField] private AudioSource _hit;

    public void PlaySFX(ESoundType soundType)
    {
        switch (soundType)
        {
            case ESoundType.Hit:
                _hit.Play();
                break;
            case ESoundType.NoteSpawn:
                _noteSpawn.Play();
                break;
        }
    }
}