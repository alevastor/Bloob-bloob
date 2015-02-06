using UnityEngine;
using System.Collections;

public class AccelerationInput : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Input.acceleration.x, 0, Input.acceleration.z);
    }
}
