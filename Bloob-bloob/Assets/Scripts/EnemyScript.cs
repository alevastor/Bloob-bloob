using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	void Start () 
    {
        rigidbody2D.AddForce(new Vector2((transform.position.x > 0) ? -100 : 100, 0));
	}
	
	void Update () 
    {
	    if(transform.position.x > 4.5f || transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
	}
}
