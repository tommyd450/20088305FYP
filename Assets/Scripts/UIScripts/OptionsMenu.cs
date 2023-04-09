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

    public void GoBack() 
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void VolumePref() 
    {
        sfx.audioMixer.SetFloat("SFX Volume", Mathf.Log10(sfxSlider.GetComponent<Slider>().value) *20);
        music.audioMixer.SetFloat("Music Volume", Mathf.Log10(musicSlider.GetComponent<Slider>().value) * 20);
    }
}
