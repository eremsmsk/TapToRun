using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundControl : MonoBehaviour
{
    AudioSource SoundControl;
    public GameObject SoundOn, SoundOff;
    // Start is called before the first frame update
    void Start()
    {
        SoundControl = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void soundState(string State)
    {
        if (State == "On")
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
            SoundControl.mute = false;

        }
        else if (State == "Off")
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
            SoundControl.mute = true;
        }
    }
}
