using UnityEngine;
using System.Collections;

public class ParticlesAutoDestroy : MonoBehaviour
{
    void Update()
    {
        if (gameObject.particleSystem.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
