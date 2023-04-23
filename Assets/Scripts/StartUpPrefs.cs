using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartUpPrefs : MonoBehaviour
{
    public AudioMixerGroup sfx;
    public AudioMixerGroup music;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            
            sfx.audioMixer.SetFloat("SFX Volume", Mathf.Log10(PlayerPrefs.GetFloat("SFX Volume")) * 20);
        }
        if (PlayerPrefs.HasKey("Music Volume"))
        {
           
            music.audioMixer.SetFloat("Music Volume", Mathf.Log10(PlayerPrefs.GetFloat("Music Volume")) * 20);
        }
        if (PlayerPrefs.HasKey("TotalEnemiesKilled")) 
        {
            PlayerPrefs.SetFloat("TotalEnemiesKilled", 0);
        }
        if (PlayerPrefs.HasKey("TotalRoomsCleared"))
        {
            PlayerPrefs.SetFloat("TotalEnemiesKilled", 0);
        }
        if (PlayerPrefs.HasKey("Currency")) 
        {
            PlayerPrefs.SetFloat("Currency", 0);
        }
        if (PlayerPrefs.HasKey("HealthCost"))
        {
            PlayerPrefs.SetFloat("HealthCost", 100);
        } else if (!PlayerPrefs.HasKey("HealthCost")) 
        {
            PlayerPrefs.SetFloat("HealthCost", 100);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
