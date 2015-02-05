using UnityEngine;
using System.Collections;

public class ChildImageScript : MonoBehaviour
{
    public Vector3 offset;

    void Start()
    {
        transform.position = new Vector3(-30, -30, -30);
    }

    void Update()
    {
        Vector3 pos;
        pos = transform.parent.transform.position;
        pos = new Vector3(pos.x + offset.x/10f, pos.y + offset.y/10f, pos.z + offset.z/10f);
        transform.position = pos;
    }
}
