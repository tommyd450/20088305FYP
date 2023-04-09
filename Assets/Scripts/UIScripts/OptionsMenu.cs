using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject musicSlider;
    public GameObject sfxSlider;
    public AudioMixerGroup sfx;
    public AudioMixerGroup music;

    

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            sfxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFX Volume");
            sfx.audioMixer.SetFloat("SFX Volume", Mathf.Log10(sfxSlider.GetComponent<Slider>().value) * 20);
        }
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music Volume");
            music.audioMixer.SetFloat("Music Volume", Mathf.Log10(musicSlider.GetComponent<Slider>().value) * 20);
        }
        
        
    }


    public void GoBack() 
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void VolumePref() 
    {
        PlayerPrefs.SetFloat("SFX Volume", sfxSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("Music Volume", musicSlider.GetComponent<Slider>().value);
        sfx.audioMixer.SetFloat("SFX Volume", Mathf.Log10(sfxSlider.GetComponent<Slider>().value) *20);
        music.audioMixer.SetFloat("Music Volume", Mathf.Log10(musicSlider.GetComponent<Slider>().value) * 20);
        
    }
}
