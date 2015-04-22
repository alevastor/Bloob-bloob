using UnityEngine;
using System.Collections;

public class ParticlesAutoDestroy : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<ParticleSystem>().isStopped)
        {
            Destroy(gameObject);
        }
    }
}
