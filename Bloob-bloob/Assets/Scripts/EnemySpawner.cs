using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject enemyObject;

	void Start () 
    {
	    
	}
	
	void Update () 
    {
	    if(Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 newPosition = new Vector3((Random.Range(0, 2) == 0) ? -4.5f : 4.5f, Random.Range(-6f, 6f), 0);
            Debug.Log(Random.Range(0, 2));
            Instantiate(enemyObject, newPosition, transform.rotation);
        }
	}
}
