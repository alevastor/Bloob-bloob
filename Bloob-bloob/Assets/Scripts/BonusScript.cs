using UnityEngine;
using System.Collections;

public class BonusScript : MonoBehaviour
{
    void Start()
    {
        bool isBack = false;
        isBack = (Random.Range(0, 2) == 0) ? true : false;
        if (!isBack)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Enemies";
        }
        else
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Enemies_Back";
            transform.localScale = new Vector3(0.8f, 0.8f, 1f);
            spriteRenderer.color = new Color(0.6f, 0.6f, 0.6f, 1f);
        }
    }

    void Update()
    {

    }
}
