using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject BtnOn, BtnOff;
    public static AdMobManager instance;
    public GameObject restartWindow;
    public GameObject exitWindow;
    private float timer = 0.2f;
    public GameObject wallPart;
    public InterstitialAd _fullscreenAd;
    public AudioClip MusicSound;
    public AudioSource Music;
    // Tam ekran reklam göstermek için gereken test id si
    private string _fullScreenAdId = "ca-app-pub-1675724970226756/4646651433";

    delegate void TurnDelegate();
    TurnDelegate turnDelegate;
    public float moveSpeed = 2;
    bool lookingRigth = true;
    GameManager gameManager;
    Animator anim;
    public Transform rayOrigin;
    public Text txtScore, txtHScore;
    public ParticleSystem effect;
    public int counter;
    bool die = true;
    bool boolSound;
    string btnTag;
    
    public int Score { get; private set; }
    public int HScore { get; private set; }
    void Start()
    {

            #region PLATFORM FOR TURNING

            #if UNITY_EDITOR
                    turnDelegate = TurnPlayerUsingKeybord;
            #endif

            #if UNITY_ANDROID
                    turnDelegate = TurnPlayerUsingTouch;
            #endif
            #endregion

        counter = 0;
        Music.clip = MusicSound;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        anim = gameObject.GetComponent<Animator>();

        LoadHighScore();
        Kill();
        requestFullScreenAd();

    }
    private void Kill()
    {
        counter = PlayerPrefs.GetInt("kill");
    }
    private void KillCounter()
    {
        counter++;        
        PlayerPrefs.SetInt("kill", counter);
        
    }
    private void LoadHighScore()
    {
        HScore = PlayerPrefs.GetInt("hiscore");
        txtHScore.text = HScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameStarted) return;

        anim.SetTrigger("gameStarted");

        moveSpeed *= 1.0001f;
        //transform.position += transform.forward*Time.deltaTime*2;
        transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);

        turnDelegate();

        CheckFalling();
        if (PlayerPrefs.GetInt("goldSound") == 1)
        {
            BtnOn.SetActive(true);
            BtnOff.SetActive(false);
        }
        else
        {
            BtnOn.SetActive(false);
            BtnOff.SetActive(true);
        }

    }
    float elapsedTime = 0;
    float freq = 1f / 5f;


    private void TurnPlayerUsingKeybord()
    {
        GameObject eventSystem = EventSystem.current.currentSelectedGameObject;
        if (eventSystem != null)
        {
            if (eventSystem.name != "BtnOn" || eventSystem.name != "BtnOff")
            {
                if (Input.GetMouseButtonDown(0)) Turn();
            }
        }

        if (Input.GetMouseButtonDown(0)) Turn();
    }
    private void TurnPlayerUsingTouch()
    {
        GameObject eventSystem = EventSystem.current.currentSelectedGameObject;

        if (eventSystem != null)
        {
            if (eventSystem.name != "BtnOn" || eventSystem.name != "BtnOff")
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) Turn();
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) Turn();

    }

    private void CheckFalling()
    {

        if ((elapsedTime += Time.deltaTime) > freq)
        {

        }
        if (!Physics.Raycast(rayOrigin.position, new Vector3(0, -1, 0)))
        {

            anim.SetTrigger("falling");
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            elapsedTime = 0;
            Debug.Log(die);
            if (die)
            {
                KillCounter();
                die = false;
                Debug.Log(counter);
                if (counter % 3 == 0)
                {
                     _fullscreenAd.Show(); 
                }
            }

           

        }
    }
    private void Turn()
    {
       if (lookingRigth)
       {
            transform.Rotate(new Vector3(0, 1, 0), -90);
       }
       else
       {
            transform.Rotate(new Vector3(0, 1, 0), 90);
       }
       lookingRigth = !lookingRigth;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("GoldCoins"))
        {
            MakeScore();
            CreateEffect();
            goldState(PlayerPrefs.GetInt("goldSound"));
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject, 2);
    }

    private void CreateEffect()
    {
        var vfx = Instantiate(effect, transform);
        Destroy(vfx, 1);
    }

    private void MakeScore()
    {
        Score += 10;
        txtScore.text = Score.ToString();

        
        if (Score > HScore)
        {
            HScore = Score;
            txtScore.text = HScore.ToString();
            PlayerPrefs.SetInt("hiscore", HScore);
        }
        PlayerPrefs.SetInt("score", Score);
    }

    public void requestFullScreenAd()
    {
        _fullscreenAd = new InterstitialAd(_fullScreenAdId);

        AdRequest adRequest = new AdRequest.Builder().Build();

        _fullscreenAd.LoadAd(adRequest);

        // Reklam yüklenmesini bekler ondan sonra reklamı gösterir.
    }

    public void goldState(int State)
    {
        //btnTag = EventSystem.current.currentSelectedGameObject.name;

        if (State == 0)
        {
            BtnOn.SetActive(false);
            BtnOff.SetActive(true);
            Music.Stop();
            PlayerPrefs.SetInt("goldSound", 0);
            

        }
        else if (State == 1)
        {
            BtnOn.SetActive(true);
            BtnOff.SetActive(false);
            Music.Play();
            PlayerPrefs.SetInt("goldSound", 1);


        }
    }

}
