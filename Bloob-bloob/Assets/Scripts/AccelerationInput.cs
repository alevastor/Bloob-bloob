using UnityEngine;
using System.Collections;

public class AccelerationInput : MonoBehaviour
{
    float myXaccel = 0.0f;
    float smoothSpeed = 3.0f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 acceler = Input.acceleration;
        Vector3 pos = transform.position;
        acceler.Normalize();
        myXaccel = Mathf.Lerp(myXaccel, acceler.x, smoothSpeed * Time.deltaTime);
        pos.x = -myXaccel * 100f;
        pos.y = Mathf.Abs(myXaccel) * 30f;
        Debug.Log(myXaccel);
        transform.position = pos;
    }
}
