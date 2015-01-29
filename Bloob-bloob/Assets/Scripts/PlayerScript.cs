using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    public static float playerSpeed = 1f;

    private AliveScript aliveScript;

	void Start () 
    {
        aliveScript = gameObject.GetComponent<AliveScript>();
	}
	
	void Update () 
    {
        playerSpeed += 0.01f * Time.deltaTime;

        if(aliveScript.isAlive())
        {
            // hero still alive
        }
        else
        {
            Debug.Log("hero is now dead");
            // hero not alive anymore
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Enemy1(Clone)")
        {
            coll.gameObject.GetComponent<AliveScript>().gotDamage();
            aliveScript.gotDamage();
        }
    }
}
