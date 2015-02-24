using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

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
        if(highScore > 0f)
        {
            Social.ReportScore((long)highScore, "CgkIsa-15KkVEAIQAQ", (bool success) =>
            {
                // handle success or failure
            });
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<AliveScript>().IsAlive())
            {
                currentScore += PlayerScript.playerSpeed * Time.timeScale / 10f;
                if (currentScore > 250f)
                {
                    Social.ReportProgress("CgkIsa-15KkVEAIQAg", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
                    if (currentScore > 600f)
                    {
                        Social.ReportProgress("CgkIsa-15KkVEAIQAw", 100.0f, (bool success) =>
                        {
                            // handle success or failure
                        });
                        if (currentScore > 1000f)
                        {
                            Social.ReportProgress("CgkIsa-15KkVEAIQBA", 100.0f, (bool success) =>
                            {
                                // handle success or failure
                            });
                            if (currentScore > 1500f)
                            {
                                Social.ReportProgress("CgkIsa-15KkVEAIQBQ", 100.0f, (bool success) =>
                                {
                                    // handle success or failure
                                });
                                if (currentScore > 2000f)
                                {
                                    Social.ReportProgress("CgkIsa-15KkVEAIQBg", 100.0f, (bool success) =>
                                    {
                                        // handle success or failure
                                    });
                                }
                            }
                        }
                    }
                }
                text.text = ((int)(currentScore)).ToString();
                highScoreText.text = "";
            }
        }
        else
        {
            if (currentScore > 0f)
            {
                googleAnalytics.LogEvent(new EventHitBuilder().SetEventCategory("Level End").SetEventAction("Player Score").SetEventLabel(currentScore.ToString()));
            }
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetFloat("High Score", highScore);
                Social.ReportScore((long)highScore, "CgkIsa-15KkVEAIQAQ", (bool success) =>
                {
                    // handle success or failure
                });
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
