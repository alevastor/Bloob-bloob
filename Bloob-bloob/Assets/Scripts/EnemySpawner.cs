using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public float timeToFirstSpawn = 3f;
    public float minTimeInterval = 0.5f;
    public float maxTimeInterval = 3f;
    public float minHorizontalSpawnPosition = -4.5f;
    public float maxHorizontalSpawnPosition = 4.5f;
    public float minVerticalSpawnPosition = -4f;
    public float maxVerticalSpawnPosition = 6f;

    private float timeToSpawn;

    void Start()
    {
        timeToSpawn = Random.Range(minTimeInterval, maxTimeInterval);
        if(timeToSpawn < timeToFirstSpawn)
        {
            timeToSpawn = timeToFirstSpawn;
        }
    }

    void Update()
    {
        if (timeToSpawn <= 0)
        {
            Vector3 newPosition = new Vector3((Random.Range(0, 2) == 0) ? minHorizontalSpawnPosition : maxHorizontalSpawnPosition, Random.Range(minVerticalSpawnPosition, maxVerticalSpawnPosition), 0);
            Instantiate(enemyObject, newPosition, transform.rotation);
            timeToSpawn = Random.Range(minTimeInterval / PlayerScript.playerSpeed, maxTimeInterval / PlayerScript.playerSpeed);
        }
        timeToSpawn -= Time.deltaTime;
    }

    public void StopSpawn()
    {
        timeToSpawn = 999;
    }
}
