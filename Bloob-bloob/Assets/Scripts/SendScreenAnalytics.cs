using UnityEngine;
using System.Collections;

public class SendScreenAnalytics : MonoBehaviour
{
    GoogleAnalyticsV3 googleAnalytics;

    void Start()
    {
        googleAnalytics = GameObject.FindGameObjectWithTag("GoogleAnalyticsObject").GetComponent<GoogleAnalyticsV3>();
        string screenName = gameObject.name;
        if(screenName.IndexOf("(Clone)") > 0 ) screenName = screenName.Substring(0, screenName.IndexOf("(Clone)"));
        googleAnalytics.LogScreen(new AppViewHitBuilder().SetScreenName(screenName));
        GameObject.Find("GM").GetComponent<SoundControl>().CheckSoundState();
    }
}
