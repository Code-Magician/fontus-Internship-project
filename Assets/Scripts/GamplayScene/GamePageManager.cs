using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GamePageManager : MonoBehaviour
{
    #region PUBLIC FIELDS

    /// <summary>
    /// Singleton intance of GamePageManager class.
    /// </summary>
    public static GamePageManager instance;

    /// <summary>
    /// event fired when start game timer is over.
    /// </summary>
    public event EventHandler OnStartTimerOver;

    #endregion


    #region PRIVATE FIELDS

    /// <summary>
    /// Boolean to let the manager know if game is over or not.
    /// </summary>
    private bool gameOver = false;

    /// <summary>
    /// Stores Game over Sounnd clip.
    /// </summary>
    [SerializeField] AudioClip gameoverClip;

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
    /// Prefix of the displayed score text.
    /// </summary>
    private string scoreUI_TextPrefix = "Score : ";

    /// <summary>
    /// Stores the reference of the Text UI which displays the Game start timer.
    /// </summary>
    [SerializeField] Text gameStartTimerText;

    /// <summary>
    /// Amount of time in seconds to wait before the game starts.
    /// </summary>
    [SerializeField] int gameStartTimerMagnitude;

    /// <summary>
    /// Stores the game's Current session score.
    /// </summary>
    private int score = 0;

    /// <summary>
    /// Number of ball miss allowed.
    /// </summary>
    [SerializeField] int lives;

    /// <summary>
    /// Prefix of the displayed lives text.
    /// </summary>
    private string playerLivesTextPrefix = "Lives : ";

    /// <summary>
    /// Stores the reference of the Text UI which displays the remaining lives of player.
    /// </summary>
    [SerializeField] Text playerLivesText;

    /// <summary>
    /// Stores the gameobject of gameover panel which will be displayed when player run out of lives.
    /// </summary>
    [SerializeField] GameObject GameoverPanel;

    /// <summary>
    /// final score to be displayed when player run out of lives.
    /// </summary>
    [SerializeField] Text finalScoreText;

    #endregion


    #region  PRIVATE METHODS

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;

        AudioManager.instance.PlayBgMusic(0.5f);

        ScreenUtil.Initialize();

        cam = Camera.main;
        edgeCollider = GetComponent<EdgeCollider2D>();
        edgePoints = new Vector2[4];
        BuildGameScene();
        StartCoroutine(GameStartTimer());
    }

    /// <summary>
    /// Handles the game timer, update timer UI and fires an OnStartTimerOver event.
    /// </summary>
    private IEnumerator GameStartTimer()
    {
        for (int i = gameStartTimerMagnitude; i >= 0; i--)
        {
            gameStartTimerText.text = i.ToString("0");

            if (i != 0)
                yield return new WaitForSeconds(1f);
        }

        gameStartTimerText.gameObject.SetActive(false);
        OnStartTimerOver?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Builds the game enviroment.
    /// </summary>
    private void BuildGameScene()
    {
        AddEdgeColliders();
        AddBackground();
        SetGameUI();
    }

    /// <summary>
    /// Initializes the game UI text and other component to default.
    /// </summary>
    private void SetGameUI()
    {
        playerLivesText.text = playerLivesTextPrefix + lives.ToString("0");
        scoreUI_Text.text = scoreUI_TextPrefix + score.ToString("00");
        gameStartTimerText.text = gameStartTimerMagnitude.ToString("0");
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

    /// <summary>
    /// Reduces lives and updates the lives text in UI.
    /// and when player run out of lives it calls game over screen to be displayed.
    /// </summary>
    public void ReduceLives()
    {
        lives -= 1;
        playerLivesText.text = playerLivesTextPrefix + lives.ToString("0");

        if (lives == 0)
            Gameover();
    }

    /// <summary>
    /// Sets the gameover panel and set gameover boolen to true.
    /// </summary>
    private void Gameover()
    {
        AudioManager.instance.PlaySfx(gameoverClip, 1f);

        Time.timeScale = 0;
        gameOver = true;

        finalScoreText.text = scoreUI_TextPrefix + score.ToString("00");
        GameoverPanel.SetActive(true);
    }

    #endregion
}
