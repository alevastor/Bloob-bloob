using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;

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
        Application.LoadLevel("MainMenu"); 
        StopCoroutine("RestartGame");
    }
}
