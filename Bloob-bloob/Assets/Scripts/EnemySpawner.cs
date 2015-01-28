using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject enemyObject;
    public float minTimeInterval = 0.5f;
    public float maxTimeInterval = 3f;

    private float timeToSpawn = 2f;

	void Start () 
    {
	    
	}
	
	void Update () 
    {
	    if(Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 newPosition = new Vector3((Random.Range(0, 2) == 0) ? -4.5f : 4.5f, Random.Range(-6f, 6f), 0);
            Instantiate(enemyObject, newPosition, transform.rotation);
        }
        if (timeToSpawn <= 0)
        {
            Vector3 newPosition = new Vector3((Random.Range(0, 2) == 0) ? -4.5f : 4.5f, Random.Range(-6f, 6f), 0);
            Instantiate(enemyObject, newPosition, transform.rotation);
            timeToSpawn = Random.Range(minTimeInterval, maxTimeInterval);
        }
        timeToSpawn -= Time.deltaTime;
	}
}
