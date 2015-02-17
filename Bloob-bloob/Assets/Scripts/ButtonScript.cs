using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public GameObject elementToActivate;
    public GameObject elementToHide;

    void Start()
    {
        CheckState();
    }

    public void CheckState()
    {
        if (gameObject.name == "MusicBubble")
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                gameObject.GetComponent<Animator>().SetBool("Disactive", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Disactive", false);
            }
        }
        if (gameObject.name == "SoundsBubble")
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                gameObject.GetComponent<Animator>().SetBool("Disactive", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Disactive", false);
            }
        }
    }

    public void EnableElements()
    {
        Instantiate(elementToActivate);
        Destroy(GameObject.Find(elementToHide.name));
    }

    public void StartAnimationForSceneButtons()
    {
        gameObject.GetComponent<Animator>().SetBool("Pressed", true);
        Animator[] allChildren = GameObject.Find("Canvas").GetComponentsInChildren<Animator>();
        foreach (Animator child in allChildren)
        {
            child.SetBool("OnExit", true);
        }
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.Play();
    }

    public void StartAnimationForSettingsButtons()
    {
        gameObject.GetComponent<Animator>().SetBool("Pressed", true);
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.Play();
        CheckState();
    }

    public void CheckMusicState()
    {
        if (MusicControl.isMusicEnabled == 0)
        {
            MusicControl.isMusicEnabled = 1;
            gameObject.GetComponent<Animator>().SetBool("Disactive", false);
        }
        else
        {
            MusicControl.isMusicEnabled = 0;
            gameObject.GetComponent<Animator>().SetBool("Disactive", true);
        }
        gameObject.GetComponent<Animator>().SetBool("Pressed", false);
        GameObject.Find("GM").GetComponent<MusicControl>().CheckMusicState();
    }

    public void CheckSoundState()
    {
        if (SoundControl.isSoundEnabled == 0)
        {
            SoundControl.isSoundEnabled = 1;
            gameObject.GetComponent<Animator>().SetBool("Disactive", false);
        }
        else
        {
            SoundControl.isSoundEnabled = 0;
            gameObject.GetComponent<Animator>().SetBool("Disactive", true);
        }
        gameObject.GetComponent<Animator>().SetBool("Pressed", false);
        GameObject.Find("GM").GetComponent<SoundControl>().CheckSoundState();
    }
}
