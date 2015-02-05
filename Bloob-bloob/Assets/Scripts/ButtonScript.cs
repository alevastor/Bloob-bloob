using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public GameObject elementToActivate;
    public GameObject elementToHide;

    void Start()
    {

    }

    void Update()
    {

    }

    public void EnableElements()
    {
        Instantiate(elementToActivate, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
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
    }

    public void StartAnimationForSettingsButtons()
    {
        gameObject.GetComponent<Animator>().SetBool("Pressed", true);
    }
}
