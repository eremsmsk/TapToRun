using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdMobManager : MonoBehaviour
{
    public static AdMobManager instance;

    public InterstitialAd _fullscreenAd;
    // Tam ekran reklam göstermek için gereken test id si
    private string _fullScreenAdId = "ca-app-pub-3940256099942544/1033173712";

    public void Update()
    {
        // Klavyeden F tuşuna bastığımız zaman reklam çalışacaktır.
        if (Input.GetKeyDown(KeyCode.F))
        {
            requestFullScreenAd();
        }
    }

    // FULLSCREENAD - START
    public void requestFullScreenAd()
    {
        _fullscreenAd = new InterstitialAd(_fullScreenAdId);

        AdRequest adRequest = new AdRequest.Builder().Build();

        _fullscreenAd.LoadAd(adRequest);

        // Reklam yüklenmesini bekler ondan sonra reklamı gösterir.
        _fullscreenAd.OnAdLoaded += (sender, args) => { _fullscreenAd.Show(); };
    }
    // FULLSCREENAD - END
}
