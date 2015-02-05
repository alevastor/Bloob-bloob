using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour 
{
    public string sceneName;

	void Start () 
    {
	
	}
	
	void Update () 
    {

	}

    public void LoadLevel()
    {
        Application.LoadLevel(sceneName);
    }

    public void StartAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("Pressed", true);
    }
}
