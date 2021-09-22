using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource soundControl;
    private static SoundControl _instance = null;

    public static SoundControl Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        soundControl = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("soundState") == 1)
        {
            soundControl.mute = false;
        }
        else
        {
            soundControl.mute = true;
        }
    }
}
