using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InitializerScript : MonoBehaviour
{
    public AudioMixer musVol;
    public Slider musSlide;
    public Dropdown dropit;

    void Start()
    {
        float volume;
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musSlide.GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicVolume");
            musVol.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume"));
        }
        else
        {
            musVol.GetFloat("musicVolume", out volume);
            PlayerPrefs.SetFloat("musicVolume", volume);
            musSlide.GetComponent<Slider>().value = volume;
        }

        dropit.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("difficulty");

    }


}
