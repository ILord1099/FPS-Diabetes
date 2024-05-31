using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update

    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip deadSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioClip selectSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
