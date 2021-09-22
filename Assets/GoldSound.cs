using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSound : MonoBehaviour
{
    public AudioClip MusicSound;
    public AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        Music.clip = MusicSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoldCoins")
        {
            Debug.Log("GameMusic");
            Music.Play();
        }
    }
}
