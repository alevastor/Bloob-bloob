using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Advertisements;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class StartScript : MonoBehaviour
{
    public GoogleAnalyticsV3 googleAnalytics;
    public GameObject startObject;
    public GameObject imagesObject;
    private InterstitialAd interstitial;

    void Start()
    {
        googleAnalytics.StartSession();
        Advertisement.Initialize("131625974");
        //PlayerPrefs.SetInt("FirstStart", 1);
        if (PlayerPrefs.GetInt("FirstStart", 0) == 0) // change default to 1 to work
        {
            Instantiate(startObject);
            if (PlayerPrefs.GetInt("Music") == 1) GameObject.Find("GM").audio.Play();
        }
        else
            Instantiate(imagesObject);
        RequestInterstitial();
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {

        });
    }

    public void RequestInterstitial()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-3617707839468603/8111153894";
#elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        // Load an interstitial ad.
        interstitial.LoadAd(createAdRequest());
    }

    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
                .AddTestDevice(AdRequest.TestDeviceSimulator)
                .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
                .AddKeyword("game")
                .SetGender(Gender.Female)
                .SetBirthday(new DateTime(1985, 1, 1))
                .TagForChildDirectedTreatment(false)
                .AddExtra("color_bg", "9B30FF")
                .Build();
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            print("Interstitial is not ready yet.");
        }
    }
}
