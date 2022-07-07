using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePageManager : MonoBehaviour
{
    private Camera cam;
    private EdgeCollider2D edgeCollider;
    private Vector2[] edgePoints;

    [SerializeField] Sprite bgSprite;

    private void Awake()
    {
        ScreenUtil.Initialize();

        cam = Camera.main;
        edgeCollider = GetComponent<EdgeCollider2D>();
        edgePoints = new Vector2[5];
        AddEdgeColliders();
        AddBackground();
    }

    /// <summary>
    /// Sets the Edge collider on the edges of the Screen based on the Camera size and Screen Height and Width.
    /// </summary>
    private void AddEdgeColliders()
    {
        Vector2 bottomLeftEdge = new Vector2(ScreenUtil.BottomLeft.x, ScreenUtil.BottomLeft.y);
        Vector2 topRightEdge = new Vector2(ScreenUtil.TopRight.x, ScreenUtil.TopRight.y);
        Vector2 bottomRightEdge = new Vector2(topRightEdge.x, bottomLeftEdge.y);
        Vector2 topLeftEdge = new Vector2(bottomLeftEdge.x, topRightEdge.y);

        edgePoints[0] = bottomLeftEdge;
        edgePoints[1] = bottomRightEdge;
        edgePoints[2] = topRightEdge;
        edgePoints[3] = topLeftEdge;
        edgePoints[4] = bottomLeftEdge;

        edgeCollider.points = edgePoints;
    }

    private void AddBackground()
    {
        GameObject bgGameObj = new GameObject("Background");
        SpriteRenderer renderer = bgGameObj.AddComponent<SpriteRenderer>();
        renderer.sprite = bgSprite;
        renderer.drawMode = SpriteDrawMode.Sliced;
        renderer.size = new Vector2(ScreenUtil.ScreenWidth, ScreenUtil.ScreenHeight);

        bgGameObj.transform.position = new Vector2(0, 0);
        bgGameObj.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
