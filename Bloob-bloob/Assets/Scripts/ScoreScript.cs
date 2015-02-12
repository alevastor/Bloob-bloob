using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
    public GameObject textObject;
    public GameObject highScoreTextObject;

    private float currentScore;
    private float highScore;
    private Text text;
    private Text highScoreText;
    private GoogleAnalyticsV3 googleAnalytics;

    void Start()
    {
        currentScore = 0f;
        text = textObject.GetComponent<Text>();
        highScore = PlayerPrefs.GetFloat("High Score", 0);
        highScoreText = highScoreTextObject.GetComponent<Text>();
        googleAnalytics = GameObject.FindGameObjectWithTag("GoogleAnalyticsObject").GetComponent<GoogleAnalyticsV3>();
    }

    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            currentScore += PlayerScript.playerSpeed / 10f;
            text.text = ((int)(currentScore)).ToString();
            highScoreText.text = "";
        }
        else
        {
            if(currentScore > 0f) googleAnalytics.LogEvent(new EventHitBuilder().SetEventCategory("Level End").SetEventAction("Player Score").SetEventLabel(currentScore.ToString()));
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetFloat("High Score", highScore);
            }
            else
            {
                currentScore = 0;
            }
            text.text = "";
            highScoreText.text = "High Score: " + ((int)highScore).ToString();
        }
    }
}
