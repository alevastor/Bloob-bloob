using UnityEngine;
using System.Collections;

public class PlayerParticles : MonoBehaviour
{
    Quaternion iniRot;
    Vector3 iniPos;

    void Start()
    {
        iniRot = transform.rotation;
        iniPos = transform.position;
    }

    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<AliveScript>().IsAlive())
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }

        transform.localScale = GameObject.FindGameObjectWithTag("Player").gameObject.transform.localScale;
    }

    void LateUpdate()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<AliveScript>().IsAlive()) transform.position = iniPos;
        transform.rotation = iniRot;
    }
}
