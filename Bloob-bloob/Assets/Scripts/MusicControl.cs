using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour
{
    public static int isMusicEnabled;

    void Start()
    {
        isMusicEnabled = PlayerPrefs.GetInt("Music", 1);
        CheckMusicState();
    }

    public void CheckMusicState()
    {
        if (isMusicEnabled == 0)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        PlayerPrefs.SetInt("Music", isMusicEnabled);
    }
}
