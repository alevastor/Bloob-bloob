using UnityEngine;
using System.Collections;

public class SlideShow : MonoBehaviour
{
    public Texture2D[] slides = new Texture2D[9];
    public float changeTime = 10.0f;
    private int currentSlide = 0;
    private float timeSinceLast = 1.0f;
    public GameObject nextObject;
    public GameObject mainMenu;
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        transform.position = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(slides[currentSlide], new Rect(0, 0, slides[currentSlide].width, slides[currentSlide].height), new Vector2(0.5f, 0.5f));
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldScreenWidth / sr.sprite.bounds.size.x + 0.02f, worldScreenHeight / sr.sprite.bounds.size.y + 0.02f, 1);
    }

    void Update()
    {
        /*if (timeSinceLast > changeTime && currentSlide < slides.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(slides[currentSlide], new Rect(0, 0, slides[currentSlide].width, slides[currentSlide].height), new Vector2(0.5f, 0.5f));
            timeSinceLast = 0.0f;
            currentSlide++;
            if (currentSlide >= slides.Length)
            {
                currentSlide = 0;
            }
        }
        timeSinceLast += Time.deltaTime;*/
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("OnExit", true);
        }
    }

    public void NextSlide()
    {
        animator.SetBool("OnExit", false);
        currentSlide++;
        if (currentSlide >= slides.Length)
        {
            if (PlayerPrefs.GetInt("FirstStart") == 1)
            {
                Instantiate(nextObject);
                PlayerPrefs.SetInt("FirstStart", 0);
            }
            else
            {
                Instantiate(mainMenu);
            }
            if (PlayerPrefs.GetInt("Music") == 1) GameObject.Find("GM").audio.Play();
            Destroy(gameObject);
        }
        else
        {
            animator.SetBool("OnEnter", true);
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(slides[currentSlide], new Rect(0, 0, slides[currentSlide].width, slides[currentSlide].height), new Vector2(0.5f, 0.5f));
        }
    }

    public void Entered()
    {
        animator.SetBool("OnEnter", false);
        animator.SetBool("OnExit", false);
    }
}
