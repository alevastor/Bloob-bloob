﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public float minVerticalSpeed = 1f;
    public float maxVerticalSpeed = 5f;
    public float downSpeed = 1f;
    public GameObject particlesOnDestroy;

    private float speed;
    private MovingScript movingScript;
    private AliveScript aliveScript;
    private Animator animator;
    private bool particlesCreated = false;

    void Start()
    {
        aliveScript = gameObject.GetComponent<AliveScript>();
        movingScript = gameObject.GetComponent<MovingScript>();
        animator = gameObject.GetComponent<Animator>();

        float modifier = (transform.position.x > 0f) ? -1 : 1;
        speed = Random.Range(minVerticalSpeed, maxVerticalSpeed) * PlayerScript.playerSpeed * modifier;
        if (modifier == 1)
        {
            Quaternion rot = transform.rotation;
            rot.y = 180f;
            transform.rotation = rot;
        }

        bool isBack = false;
        isBack = (Random.Range(0, 2) == 0) ? true : false;
        if (!isBack)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Enemies";
            animator.SetBool("Back", false);
        }
        else
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Enemies_Back";
            transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            spriteRenderer.color = new Color(0.6f, 0.6f, 0.6f, 1f);
            //speed *= 0.6f;
            animator.SetBool("Back", true);
        }

        movingScript.SetVelocity(new Vector2(speed, -downSpeed * PlayerScript.playerSpeed));
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
            movingScript.SetVelocity(new Vector2(0, 0));
            if (!particlesCreated)
            {
                Instantiate(particlesOnDestroy, transform.position, transform.rotation);
                particlesCreated = true;
            }
            Destroy(gameObject, 0.3f);
        }
    }
}
