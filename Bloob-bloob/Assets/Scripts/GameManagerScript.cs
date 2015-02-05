using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject elementToShow;
    public GameObject elementToHide;
    public GameObject menuElement;

    public void StartRestarting(float secondsToRestart)
    {
        menuElement.GetComponent<Animator>().SetBool("OnExit", true);
        StartCoroutine("RestartGame", secondsToRestart);
    }

    public IEnumerator RestartGame(float secondsToRestart)
    {
        yield return new WaitForSeconds(secondsToRestart);
        RestartGameFunc();
    }

    public void RestartGameFunc()
    {
        //Application.LoadLevel("MainMenu");
        Instantiate(elementToShow);
        Destroy(GameObject.Find(elementToHide.name));
        StopCoroutine("RestartGame");
    }
}
