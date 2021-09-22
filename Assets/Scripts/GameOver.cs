using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScore;
    PlayerController playerController;
    public Text txtScore2, txtScoreName;
    public int score, hscore;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        score = PlayerPrefs.GetInt("score");
        hscore = PlayerPrefs.GetInt("hiscore");

        if (score > hscore)
        {
            txtScoreName.text = "BEST";
        }

        txtScore2.text = score.ToString();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
