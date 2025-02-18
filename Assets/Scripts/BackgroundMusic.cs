using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
