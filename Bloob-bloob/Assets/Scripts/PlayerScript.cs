using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public static float playerSpeed = 1f;

    private AliveScript aliveScript;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        aliveScript = gameObject.GetComponent<AliveScript>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(0.6f, 0.6f, 0.6f, 1f);
    }

    void Update()
    {
        //playerSpeed += 0.01f * Time.deltaTime;

        if (!aliveScript.IsAlive())
        {
            animator.SetBool("Alive", aliveScript.isAlive);
            Destroy(gameObject, 6f);
        }
        checkLayer();
    }

    void checkLayer()
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
        if (spriteRenderer.sortingLayerName == "Player_Back" && transform.localScale.x > 0.6f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, 1);
            spriteRenderer.color = new Color(spriteRenderer.color.r - 0.01f, spriteRenderer.color.g - 0.01f, spriteRenderer.color.b - 0.01f, 1f);
        }
        else if (spriteRenderer.sortingLayerName == "Player" && transform.localScale.x < 1.0f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, 1f);
            spriteRenderer.color = new Color(spriteRenderer.color.r + 0.01f, spriteRenderer.color.g + 0.01f, spriteRenderer.color.b + 0.01f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if ((coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies_Back" && spriteRenderer.sortingLayerName == "Player_Back") || (coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Enemies" && spriteRenderer.sortingLayerName == "Player"))
            {
                coll.gameObject.GetComponent<AliveScript>().GotDamage();
                coll.gameObject.GetComponent<Animator>().SetBool("Hited", true);
                aliveScript.GotDamage();
                animator.SetBool("Hited", true);
                StartCoroutine("stopHitingAnimation");
            }
        }
    }

    public IEnumerator stopHitingAnimation()
    {
        yield return new WaitForSeconds(0.75f);
        stopHitingAnimationFunc();
    }

    void stopHitingAnimationFunc()
    {
        animator.SetBool("Hited", false);
        StopCoroutine("stopHitingAnimation");
    }
}
