using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
    public int minForce = 80;
    public int maxForce = 120;

	void Start () 
    {
        rigidbody2D.AddForce(new Vector2((transform.position.x > 0) ? -Random.Range(minForce, maxForce) : Random.Range(minForce, maxForce), 0));
	}
	
	void Update () 
    {
	    if(transform.position.x > 4.5f || transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
	}
}
