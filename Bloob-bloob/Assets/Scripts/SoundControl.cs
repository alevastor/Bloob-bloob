using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour
{
    public static int isSoundEnabled;

    void Start()
    {
        isSoundEnabled = PlayerPrefs.GetInt("Sound", 1);
        CheckSoundState();
    }

    public void CheckSoundState()
    {
        AudioSource[] allAudioSources = UnityEngine.Object.FindObjectsOfType<AudioSource>();
        if (isSoundEnabled == 0)
        {
            foreach (AudioSource audio in allAudioSources)
            {
                if (audio.gameObject.name != "GM")
                {
                    audio.mute = true;
                }
            }
        }
        else
        {
            foreach (AudioSource audio in allAudioSources)
            {
                if (audio.gameObject.name != "GM")
                {
                    audio.mute = false;
                }
            }
        }
        PlayerPrefs.SetInt("Sound", isSoundEnabled);
    }

    void Update()
    {
        //CheckSoundState();
    }
}
