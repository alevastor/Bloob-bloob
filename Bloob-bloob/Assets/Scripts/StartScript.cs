using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour
{
    public GoogleAnalyticsV3 googleAnalytics;
    public GameObject startObject;

    void Start()
    {
        googleAnalytics.StartSession();
        Instantiate(startObject);
    }
}
