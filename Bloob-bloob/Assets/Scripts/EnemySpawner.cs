using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public float minTimeInterval = 0.5f;
    public float maxTimeInterval = 3f;
    public float minHorizontalSpawnPosition = -4.5f;
    public float maxHorizontalSpawnPosition = 4.5f;
    public float minVerticalSpawnPosition = -4f;
    public float maxVerticalSpawnPosition = 6f;

    private float timeToSpawn = 3f;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 newPosition = new Vector3((Random.Range(0, 2) == 0) ? minHorizontalSpawnPosition : maxHorizontalSpawnPosition, Random.Range(minVerticalSpawnPosition, maxVerticalSpawnPosition), 0);
            Instantiate(enemyObject, newPosition, transform.rotation);
        }
        if (timeToSpawn <= 0)
        {
            Vector3 newPosition = new Vector3((Random.Range(0, 2) == 0) ? minHorizontalSpawnPosition : maxHorizontalSpawnPosition, Random.Range(minVerticalSpawnPosition, maxVerticalSpawnPosition), 0);
            Instantiate(enemyObject, newPosition, transform.rotation);
            timeToSpawn = Random.Range(minTimeInterval / PlayerScript.playerSpeed, maxTimeInterval / PlayerScript.playerSpeed);
        }
        timeToSpawn -= Time.deltaTime;
    }
}
