using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 1;
    public float tileSizeY = 16;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = new Vector3(startPosition.x, startPosition.y + newPosition, startPosition.z);
    }
}