using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour
{
    public Vector2 Velocity;

    public void SetVelocity(Vector2 velocity)
    {
        Velocity = velocity;
    }

    public Vector2 GetVelocity()
    {
        return Velocity;
    }

    void Update()
    {
        if(Velocity.y < 0) 
            transform.Translate(Vector3.right * Time.deltaTime * Velocity.x / Time.timeScale + Vector3.up * Time.deltaTime * Velocity.y * Time.timeScale, Space.World);
        else
            transform.Translate(Vector3.right * Time.deltaTime * Velocity.x / Time.timeScale + Vector3.up * Time.deltaTime * Velocity.y / Time.timeScale, Space.World);
    }
}
