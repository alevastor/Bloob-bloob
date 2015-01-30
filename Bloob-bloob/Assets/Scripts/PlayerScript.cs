using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public static float playerSpeed = 1f;

    private AliveScript aliveScript;
    private Animator animator;

    void Start()
    {
        aliveScript = gameObject.GetComponent<AliveScript>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        playerSpeed += 0.01f * Time.deltaTime;

        if (aliveScript.IsAlive())
        {
            // hero still alive
        }
        else
        {
            animator.SetBool("Alive", aliveScript.isAlive);
            Destroy(gameObject, 2.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<AliveScript>().GotDamage();
            aliveScript.GotDamage();
        }
    }
}
