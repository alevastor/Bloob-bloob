using UnityEngine;
using System.Collections;

public class AliveScript : MonoBehaviour
{
    public int lifeCount = 1;
    public bool isAlive = true;

    void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        if (lifeCount <= 0)
            isAlive = false;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void GotDamage()
    {
        lifeCount--;
    }
}
