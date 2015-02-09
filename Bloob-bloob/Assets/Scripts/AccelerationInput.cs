using UnityEngine;
using System.Collections;

public class AccelerationInput : MonoBehaviour
{
    float myXaccel = 0.0f;
    float smoothSpeed = 3.0f;
    public float xBoost = 100f;
    public float yBoost = 30f;

    Vector3 pos;
    Vector3 acceler;
    float startYPosition;

    void Start()
    {
        startYPosition = transform.position.y;
    }

    void Update()
    {
        acceler = Input.acceleration;
        pos = transform.position;
        acceler.Normalize();
        myXaccel = Mathf.Lerp(myXaccel, acceler.x, smoothSpeed * Time.deltaTime);
        pos.x = -myXaccel * xBoost;
        pos.y = startYPosition + Mathf.Abs(myXaccel) * yBoost;
        transform.position = pos;
    }
}
