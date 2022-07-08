using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Gives us the Screen Height, Width in World coordinates.
/// Provides us with
/// Let's say we are in portrait Mode. then With respect to us which is x-axis on screen that will be width and the other one will be height.
/// </summary>
public class ScreenUtil
{
    #region PRIVATE FIELDS

    /// <summary>
    /// Stores the bottomLeft and topRight coordinates of the screen in world position.
    /// </summary>
    static Vector2 bottomLeftPosition, topRightPosition;

    #endregion


    #region PRIVATE FIELD GETTERS

    /// <summary>
    /// Get Top Right corner coordinate of Screen in world position.
    /// </summary>
    public static Vector2 TopRight
    {
        get { return topRightPosition; }
    }


    /// <summary>
    /// Get BottomLeft  corner coordinate of Screen in world position.
    /// </summary>
    public static Vector2 BottomLeft
    {
        get { return bottomLeftPosition; }
    }

    /// <summary>
    /// Get Screen Width corner coordinate of Screen in world position.
    /// </summary>
    public static float ScreenWidth
    {
        get { return (topRightPosition.x - bottomLeftPosition.x); }
    }

    /// <summary>
    /// Get Screen Width corner coordinate of Screen in world position.
    /// </summary>
    public static float ScreenHeight
    {
        get { return (topRightPosition.y - bottomLeftPosition.y); }
    }

    #endregion


    #region PUBLIC FUNCTIONS

    /// <summary>
    /// Calculates the bottomLeft and top right coordinates of the screen in world coordinates.
    /// </summary>
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

    #endregion
}
