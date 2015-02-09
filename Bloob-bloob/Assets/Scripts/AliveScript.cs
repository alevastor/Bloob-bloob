using UnityEngine;
using System.Collections;

public class AliveScript : MonoBehaviour
{
    public int lifeCount = 1;

    public bool IsAlive()
    {
        if (lifeCount <= 0)
            return false;
        else
            return true;
    }

    public void GotDamage()
    {
        lifeCount--;
    }

    public int GetLifeCount()
    {
        return lifeCount;
    }
}
