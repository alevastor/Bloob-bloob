using UnityEngine;
using System.Collections;

public class PiranhaScript : MonoBehaviour
{
    public float boostPosition = -2f;
    public float boostSpeed = 15f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    void Update()
    {
        if (gameObject.transform.position.y >= boostPosition)
        {
            float currentSpeed = gameObject.GetComponent<MovingScript>().GetVelocity().y;
            if (currentSpeed < boostSpeed)
                gameObject.GetComponent<MovingScript>().SetVelocity(new Vector2(0, currentSpeed + 0.1f));
        }
    }
}
