using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour 
{
    public void Move(Vector2 velocity)
    {
        transform.Translate(Vector3.right * Time.deltaTime * velocity.x + Vector3.up * Time.deltaTime * velocity.y, Space.World);
    }
}
