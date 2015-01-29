using UnityEngine;
using System.Collections;

public class AliveScript : MonoBehaviour 
{
    public int lifeCount = 1;
    public bool _isAlive = true;
	
    void Start () 
    {
        _isAlive = true;
	}
	
	void Update () 
    {
        if(lifeCount <= 0)
            _isAlive = false;
	}

    public bool isAlive()
    {
        return _isAlive;
    }

    public void gotDamage()
    {
        lifeCount--;
    }
}
