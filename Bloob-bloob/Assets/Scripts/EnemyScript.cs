using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
    public float minVerticalSpeed = 1f;
    public float maxVerticalSpeed = 5f;
    public float downSpeed = 1f;

    private float speed;
    private MovingScript movingScript;
    private AliveScript aliveScript;

	void Start () 
    {
        movingScript = gameObject.GetComponent<MovingScript>();
        aliveScript = gameObject.GetComponent<AliveScript>();

        float modifier = (transform.position.x > 0f) ? -1 : 1;
        speed = Random.Range(minVerticalSpeed, maxVerticalSpeed) * PlayerScript.playerSpeed * modifier;
	}
	
	void Update () 
    {
        if (aliveScript.isAlive())
        {
            // enemy still alive
        }
        else
        {
            // enemy not alive anymore
            Destroy(gameObject);
        }
        movingScript.Move(new Vector2(speed,-downSpeed));
	}
}
