using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Let's say we are in portrait Mode. then With respect to us which is x-axis on screen that will be width and the other one will be height.
/// </summary>
public class ScreenUtil
{
    static Vector2 bottomLeftPosition, topRightPosition;

    public static void Initialize()
    {
        // Screen Pixel Coordinates
        bottomLeftPosition = new Vector2(0, 0);
        topRightPosition = new Vector2(Screen.width, Screen.height);

        // Converting Screen Pixel to World Coordinate
        bottomLeftPosition = Camera.main.ScreenToWorldPoint(bottomLeftPosition);
        topRightPosition = Camera.main.ScreenToWorldPoint(topRightPosition);

        Debug.Log(message: $"Top Right      :{TopRight.x} {TopRight.y}");
        Debug.Log(message: $"Bottom Left    :{BottomLeft.x} {BottomLeft.y}");
    }

    public static Vector2 TopRight
    {
        get { return topRightPosition; }
    }

    public static Vector2 BottomLeft
    {
        get { return bottomLeftPosition; }
    }

    public static float ScreenWidth
    {
        get { return (topRightPosition.x - bottomLeftPosition.x); }
    }

    public static float ScreenHeight
    {
        get { return (topRightPosition.y - bottomLeftPosition.y); }
    }
}
