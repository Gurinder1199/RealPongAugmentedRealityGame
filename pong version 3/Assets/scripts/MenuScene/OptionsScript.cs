using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer musVol;
    public Slider musSlide;
    public Dropdown dropit;


    public void SetVolume(float volume)
    {
        musVol.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        switch(difficulty)
        {
            case 0:
                AIController.AIdifficulty = 0.5f;
                return;
            case 1:
                AIController.AIdifficulty = 1f;
                return;
            case 2:
                AIController.AIdifficulty = 2f;
                return;
        }
    }

    
}
