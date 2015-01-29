using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour 
{
    public float minVerticalPosition = -7.5f;
    public float maxVerticalPosition = 7.5f;
    public float minHorizontalPosition = -4.5f;
    public float maxHorizontalPosition = 4.5f;
	
	void Update ()
    {
        if (transform.position.x > maxHorizontalPosition || transform.position.x < minHorizontalPosition || transform.position.y > maxVerticalPosition || transform.position.y < minVerticalPosition)
        {
            Destroy(gameObject);
        }
	}
}
