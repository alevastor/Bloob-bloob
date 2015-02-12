﻿using UnityEngine;
using System.Collections;

public class ScreenRelativePosition : MonoBehaviour
{
    public enum ScreenEdge { LEFT, RIGHT, TOP, BOTTOM };
    public ScreenEdge screenEdge;
    public float yOffset;
    public float xOffset;

    void Start()
    {
        Vector3 newPosition = transform.position;
        Camera camera = Camera.main;
        switch (screenEdge)
        {
            case ScreenEdge.RIGHT:
                newPosition.x = camera.aspect * camera.orthographicSize + xOffset;
                newPosition.y = yOffset;
                break;
            case ScreenEdge.TOP:
                newPosition.y = camera.orthographicSize + yOffset;
                newPosition.x = xOffset;
                break;
            case ScreenEdge.LEFT:
                newPosition.x = -camera.aspect * camera.orthographicSize + xOffset;
                newPosition.y = yOffset;
                break;
            case ScreenEdge.BOTTOM:
                newPosition.y = -camera.orthographicSize + yOffset;
                newPosition.x = xOffset;
                break;
        }
        gameObject.transform.position = newPosition;
    }

    void Update()
    {

    }
}
