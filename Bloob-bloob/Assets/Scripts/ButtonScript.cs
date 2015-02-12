using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public GameObject elementToActivate;
    public GameObject elementToHide;

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
    }
}
