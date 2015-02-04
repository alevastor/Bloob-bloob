using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {

    }

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
        Application.LoadLevel(0); 
        StopCoroutine("RestartGame");
    }
}
