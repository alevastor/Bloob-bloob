using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Effects";
    }
}