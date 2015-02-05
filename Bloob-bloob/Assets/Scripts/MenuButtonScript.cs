using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<Animator>().SetBool("Pressed", true);
            Animator[] allChildren = GameObject.Find("Canvas").GetComponentsInChildren<Animator>();
            foreach (Animator child in allChildren)
            {
                child.SetBool("OnExit", true);
            }
        }
    }
}
