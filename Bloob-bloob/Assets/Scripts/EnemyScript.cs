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

    void Start()
    {
        aliveScript = gameObject.GetComponent<AliveScript>();
        movingScript = gameObject.GetComponent<MovingScript>();

        float modifier = (transform.position.x > 0f) ? -1 : 1;
        speed = Random.Range(minVerticalSpeed, maxVerticalSpeed) * PlayerScript.playerSpeed * modifier;
        movingScript.SetVelocity(new Vector2(speed, -downSpeed));
    }

    void Update()
    {
        if (aliveScript.IsAlive())
        {
            // enemy still alive
        }
        else
        {
            // enemy not alive anymore
            Destroy(gameObject);
        }
    }
}
