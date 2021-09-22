using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    //private static BackgroundSound _instance = null;
    //public static BackgroundSound Instance
    //{
    //    get { return _instance; }
    //}
    public GameObject BackSoundOn, BackSoundOff;
    public BackgroundSound instance;
    //AudioSource SoundControl;
    //public GameObject BackSoundOn, BackSoundOff;

    //private void Awake()
    //{
    //    if (_instance == null)
    //    {
    //        _instance = this;
    //        DontDestroyOnLoad(this);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(instance);

        //SoundControl = GetComponent<AudioSource>();
    }
    private void Update()
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

    //public void SoundOn()
    //{
    //    BackSoundOn.SetActive(false);
    //    BackSoundOff.SetActive(true);
    //    //SoundControl.mute = true;
    //    Debug.Log("ON");
    //    PlayerPrefs.SetInt("soundState", 0);

    //}
    //public void SoundOff()
    //{
    //    BackSoundOn.SetActive(true);
    //    BackSoundOff.SetActive(false);
    //    //SoundControl.mute = false;
    //    Debug.Log("OFF");
    //    PlayerPrefs.SetInt("soundState", 1);
    //}
}
