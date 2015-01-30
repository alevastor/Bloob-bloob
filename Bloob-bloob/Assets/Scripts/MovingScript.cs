using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour
{
    public Vector2 Velocity;

    public void SetVelocity(Vector2 velocity)
    {
        Velocity = velocity;
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Velocity.x + Vector3.up * Time.deltaTime * Velocity.y, Space.World);
    }
}
