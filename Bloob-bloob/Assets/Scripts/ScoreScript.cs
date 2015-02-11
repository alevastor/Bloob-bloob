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

    void Start()
    {
        currentScore = 0f;
        text = textObject.GetComponent<Text>();
        highScore = PlayerPrefs.GetFloat("High Score", 0);
        highScoreText = highScoreTextObject.GetComponent<Text>();
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
