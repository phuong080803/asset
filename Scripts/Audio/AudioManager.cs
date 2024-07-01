using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsoure;
    public AudioClip Background;
    public AudioClip hit;
    public AudioClip fire;
    public void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audioClip)
    {
        SFXsoure.PlayOneShot(audioClip);
    }
}
