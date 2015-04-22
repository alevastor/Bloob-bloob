using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public float startPlayerSpeed = 1f;
    public static float playerSpeed = 1f;
    public GameObject livesObject;

    private GoogleAnalyticsV3 googleAnalytics;
    private float timeFromStart;
    private AliveScript aliveScript;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource[] aSources;
    GameObject[] lifeIcons;
    private float playerSpeedSaver;
    private bool isSpeedingUp = false;

    void Start()
    {
        aSources = gameObject.GetComponents<AudioSource>();
        aliveScript = gameObject.GetComponent<AliveScript>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (playerSpeed != startPlayerSpeed) playerSpeed = startPlayerSpeed;
        transform.position = new Vector3(-100, -100, -100); //to prevent flickering

        spriteRenderer.color = new Color(0.6f, 0.6f, 0.6f, 1f);
        DrawLives();
        lifeIcons = GameObject.FindGameObjectsWithTag("LifeIcon");
        googleAnalytics = GameObject.FindGameObjectWithTag("GoogleAnalyticsObject").GetComponent<GoogleAnalyticsV3>();
        googleAnalytics.LogEvent(new EventHitBuilder().SetEventCategory("Level Start").SetEventAction("Level Started"));
        timeFromStart = Time.time;
    }

    void Update()
    {
        playerSpeed += 0.03f * Time.deltaTime;
        if (isSpeedingUp)
            Time.timeScale += 0.8f * Time.deltaTime;
        else
            if (Time.timeScale > 1f)
                Time.timeScale -= 0.8f * Time.deltaTime;
        if (Time.timeScale < 1f) Time.timeScale = 1f;

        if (!aliveScript.IsAlive())
        {
            animator.SetBool("Alive", aliveScript.IsAlive());
            GameObject gameManager;
            gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManagerScript>().StartRestarting(3f);
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().StopSpawn();
            GameObject.Find("EnemySpawnerSharks").GetComponent<EnemySpawner>().StopSpawn();
            aSources[0].Stop();
            Destroy(gameObject, 3.5f);
        }
        CheckLayer();
    }

    void DrawLives(bool destroyAll = false)
    {
        if (destroyAll)
            foreach (GameObject go in lifeIcons)
                Destroy(go);
        else
            for (float i = 0; i < aliveScript.GetLifeCount(); i++)
            {
                Vector3 newPosition = transform.position;
                Camera camera = Camera.main;
                newPosition.x = -camera.aspect * camera.orthographicSize + 0.5f;
                newPosition.y = 6f - 0.8f * i;
                Instantiate(livesObject, new Vector3(newPosition.x, newPosition.y, 0), transform.rotation);
            }
    }

    void CheckLayer()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (spriteRenderer.sortingLayerName == "Player_Back")
                {
                    spriteRenderer.sortingLayerName = "Player";
                    animator.SetBool("Back", false);
                }
                else
                {
                    spriteRenderer.sortingLayerName = "Player_Back";
                    animator.SetBool("Back", true);
                }
            }
        }
        if (spriteRenderer.sortingLayerName == "Player_Back" && transform.localScale.x > 0.6f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, 1f);
            if (aSources[0].pitch > 0.5f) aSources[0].pitch -= 0.01f;
        }
        else if (spriteRenderer.sortingLayerName == "Player" && transform.localScale.x < 1.0f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, 1f);
            if (aSources[0].pitch < 0.9f) aSources[0].pitch += 0.01f;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && aliveScript.IsAlive())
        {
            if ((coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies_Back" && spriteRenderer.sortingLayerName == "Player_Back") || (coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies" && spriteRenderer.sortingLayerName == "Player"))
            {
                if (coll.gameObject.GetComponent<AliveScript>().IsAlive() && animator.GetBool("Hited") == false)
                {
                    aliveScript.GotDamage();
                    coll.gameObject.GetComponent<AliveScript>().GotDamage();
                    lifeIcons[aliveScript.GetLifeCount()].transform.position = new Vector3(10, 10, 0);
                }
                animator.SetBool("Hited", true);
                coll.gameObject.GetComponent<Animator>().SetBool("Hited", true);
                aSources[1].pitch = Random.Range(0.4f, 0.8f);
                aSources[1].Play();
                StartCoroutine("StopHitingAnimation");
            }
        }
        if (coll.gameObject.tag == "LifeBonus" && aliveScript.IsAlive())
        {
            if ((coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies_Back" && spriteRenderer.sortingLayerName == "Player_Back") || (coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies" && spriteRenderer.sortingLayerName == "Player"))
            {
                aliveScript.GotLife();
                for (int i = 0; i < aliveScript.GetLifeCount(); i++)
                {
                    Vector3 newPosition = transform.position;
                    Camera camera = Camera.main;
                    newPosition.x = -camera.aspect * camera.orthographicSize + 0.5f;
                    newPosition.y = 6f - 0.8f * (float)i;
                    lifeIcons[i].transform.position = new Vector3(newPosition.x, newPosition.y, 0);
                }
                Destroy(coll.gameObject);
            }
        }
        if (coll.gameObject.tag == "SpeedBonus" && aliveScript.IsAlive())
        {
            if ((coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies_Back" && spriteRenderer.sortingLayerName == "Player_Back") || (coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies" && spriteRenderer.sortingLayerName == "Player"))
            {
                SpeedUp();
                StartCoroutine("SlowDown");
                Destroy(coll.gameObject);
            }
        }
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
        timeFromStart = Time.time - timeFromStart;
        googleAnalytics.LogEvent(new EventHitBuilder().SetEventCategory("Level End").SetEventAction("Level Time").SetEventLabel(timeFromStart.ToString()));
        Debug.Log("Time from start: " + timeFromStart);
        DrawLives(true);
        if (aliveScript.GetLifeCount() == 0)
        {
            if (Advertisement.isReady())
            {
                Advertisement.Show();
            }
            else
            {
                GameObject.Find("MainObjects").GetComponent<StartScript>().ShowInterstitial();
                GameObject.Find("MainObjects").GetComponent<StartScript>().RequestInterstitial();
            }
        }
    }

    public IEnumerator StopHitingAnimation()
    {
        yield return new WaitForSeconds(0.75f);
        StopHitingAnimationFunc();
    }

    void StopHitingAnimationFunc()
    {
        animator.SetBool("Hited", false);
        StopCoroutine("StopHitingAnimation");
    }

    void SpeedUp()
    {
        isSpeedingUp = true;
    }

    public IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(2f);
        SlowDownFunc();
    }

    void SlowDownFunc()
    {
        isSpeedingUp = false;
        StopCoroutine("SlowDown");
    }
}