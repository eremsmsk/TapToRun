using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public GameObject BackSoundOn, BackSoundOff;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("soundState") == 1)
        {
            BackSoundOn.SetActive(true);
            BackSoundOff.SetActive(false);
        }
        else
        {
            BackSoundOn.SetActive(false);
            BackSoundOff.SetActive(true);
        }
    }

    public void SoundState(string State)
    {
        if (State == "On")
        {
            BackSoundOn.SetActive(false);
            BackSoundOff.SetActive(true);
            PlayerPrefs.SetInt("soundState", 0);
        }
        else if (State == "Off")
        {
            BackSoundOn.SetActive(true);
            BackSoundOff.SetActive(false);
            PlayerPrefs.SetInt("soundState", 1);
        }
    }
}
