using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject elementToShow;
    public GameObject elementToHide;

    public void StartRestarting(float secondsToRestart)
    {
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
