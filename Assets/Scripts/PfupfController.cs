using UnityEngine;

public class PfupfController : BeingController
{

    public AudioClip[] repellingAudioClips; 
    public AudioClip[] complainingAudioClips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Update ()
    {
        base.Update();
        if (numberOfBlankets == maxNumberOfBlankets) {
            gameManager.gameWon();
        }
        // TO DO: complaining audio clips...
    }

    protected override void OnTriggerEnter (Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Blanket") && numberOfBlankets < maxNumberOfBlankets && partnerController!=null)
        {
            PlayAudio(true);
            other.gameObject.tag = "BlanketInPlace";
            partnerController.numberOfBlankets--;
            
        }
    }

    private void PlayAudio(bool pookieCloseBy)
    {
        if (pookieCloseBy)
        {
            audioSource.PlayOneShot(repellingAudioClips[Random.Range(0, repellingAudioClips.Length)]);
        }
        else
        {
            audioSource.PlayOneShot(complainingAudioClips[Random.Range(0, complainingAudioClips.Length)]);
        }
    }
}

