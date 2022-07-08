using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePageManager : MonoBehaviour
{
    public static GamePageManager instance;

    #region PRIVATE FIELDS

    /// <summary>
    /// stores the reference of the main camera.
    /// </summary>
    private Camera cam;

    /// <summary>
    /// Stores the reference of the edge colliders
    /// </summary>
    private EdgeCollider2D edgeCollider;

    /// <summary>
    /// Stores all the edgePoints used by the edge collider.
    /// </summary>
    private Vector2[] edgePoints;

    /// <summary>
    /// Gets the reference of the background sprite to be used from the inspector.
    /// </summary>
    [SerializeField] Sprite bgSprite;

    /// <summary>
    /// Stores the reference of the Text UI which displays the current score.
    /// </summary>
    [SerializeField] Text scoreUI_Text;

    /// <summary>
    /// Prefix of the displayed text.
    /// </summary>
    private string scoreUI_TextPrefix = "Score : ";

    #endregion


    #region PUBLIC METHODS

    /// <summary>
    /// Stores the game's Current session score.
    /// </summary>
    public int score = 0;

    #endregion


    #region  PRIVATE METHODS

    private void Awake()
    {
        instance = this;

        AudioManager.instance.PlayBgMusic(0.5f);

        ScreenUtil.Initialize();

        cam = Camera.main;
        edgeCollider = GetComponent<EdgeCollider2D>();
        edgePoints = new Vector2[4];
        BuildGameScene();
    }

    /// <summary>
    /// Builds the game enviroment.
    /// </summary>
    private void BuildGameScene()
    {
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

        edgePoints[0] = topLeftEdge;
        edgePoints[1] = bottomLeftEdge;
        edgePoints[2] = bottomRightEdge;
        edgePoints[3] = topRightEdge;

        edgeCollider.points = edgePoints;
    }

    /// <summary>
    /// Makes new Gameobject. Adds spriterenderer to it and expands it's size to fit the screen.
    /// </summary>
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

    #endregion


    #region PUBLIC METHODS

    /// <summary>
    /// loads the scene using the name of the scene.
    /// </summary>
    /// <param name="sceneName">scene name (in string) to be loaded.</param>
    public void GotoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Updates the score on the UI.
    /// </summary>
    public void AddPoints(int points)
    {
        score += points;
        scoreUI_Text.text = scoreUI_TextPrefix + score.ToString("00");
    }

    #endregion
}
