using UnityEngine;
using System.Collections;

public class SpeederScript : MonoBehaviour
{
    void SpeedUp()
    {
        Time.timeScale = 2f;
    }

    void SlowDown()
    {
        Time.timeScale = 1f;
    }
}
