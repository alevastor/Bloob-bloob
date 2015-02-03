using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour
{
    void Start()
    {
        particleSystem.renderer.sortingLayerName = "Effects";
    }
}
