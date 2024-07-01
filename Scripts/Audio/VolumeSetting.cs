using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
   
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    private void Start()
    {
        if(PlayerPrefs.HasKey("Music Volume"))
        {
            LoadVolume();
            
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
        
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Music Volume", volume);
 
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music Volume");
        SetMusicVolume();
        SFXSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        SetSFXVolume();

    }
    public void SetSFXVolume()
    {

        float volume2 = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume2) * 20);
        PlayerPrefs.SetFloat("SFX Volume", volume2);
    }
   
}
