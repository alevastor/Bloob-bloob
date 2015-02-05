using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour
{
    public GameObject startObject;

    void Start()
    {
        Instantiate(startObject);
    }

    void Update()
    {

    }
}
