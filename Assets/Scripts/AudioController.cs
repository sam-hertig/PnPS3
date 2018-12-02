using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip[] RepellingAudioClips;
    public AudioClip[] ComplainingAudioClips;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(bool proximity)
    {
        if (proximity)
        {
            _audioSource.PlayOneShot(RepellingAudioClips[Random.Range(0, RepellingAudioClips.Length)]);
        }
        else
        {
            _audioSource.PlayOneShot(ComplainingAudioClips[Random.Range(0, ComplainingAudioClips.Length)]);
        }
    }
}
