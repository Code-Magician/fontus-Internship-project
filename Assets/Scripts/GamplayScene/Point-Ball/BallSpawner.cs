using UnityEngine;
using System;

public class BallSpawner : MonoBehaviour
{
    #region PRIVATE FIELDS

    /// <summary>
    /// Reference to the ballview of ball prefab.
    /// </summary>
    [SerializeField] BallView ball;

    /// <summary>
    /// Reference to the Circle collider of the ball prefab.
    /// </summary>
    [SerializeField] CircleCollider2D ballCollider;

    /// <summary>
    /// Range of speed of the moving ball.
    /// </summary>
    [SerializeField] float minBallSpeed, maxBallSpeed;

    /// <summary>
    /// Reference to the clips when ball collides with player and ground repectively.
    /// </summary>
    [SerializeField] AudioClip scoreClip, groundTouchClip;

    #endregion


    #region PUBLIC FUNCTIONS

    /// <summary>
    /// Function which is Subscribed to the OnStartTimerOver event.
    /// it spaws the balls every 3second.
    /// </summary>
    /// <param name="sender">Sender object who fired the event.</param>
    /// <param name="e">Arguments passed when event was fired.</param>
    public void PeriodicBallSpawning(object sender, EventArgs e)
    {
        GamePageManager.instance.OnStartTimerOver -= PeriodicBallSpawning;
        InvokeRepeating("SpawnBall", 0, 3f);
    }

    #endregion


    #region PRIVATE FUNCTIONS

    private void Start()
    {
        GamePageManager.instance.OnStartTimerOver += PeriodicBallSpawning;
    }

    /// <summary>
    /// Calculates the positon to spawn ball(above the screen).
    /// Instantiates the ball and sets all the references required by the ballview script attacked to the ball gameobject spawned.
    /// </summary>
    private void SpawnBall()
    {
        float xLeft = ScreenUtil.BottomLeft.x + 2 * ballCollider.radius;
        float xRight = ScreenUtil.TopRight.x - 2 * ballCollider.radius;
        float yUp = ScreenUtil.TopRight.y + 2 * ballCollider.radius;

        Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(xLeft, xRight), yUp);

        BallView ballView = Instantiate<BallView>(ball, spawnPos, Quaternion.identity);

        ballView.OnCollisionWithPlayer += AddPoints;
        ballView.OnCollisionWithGround += ReduceLives;

        ballView.ballSpeed = UnityEngine.Random.Range(minBallSpeed, maxBallSpeed);
        ballView.scoreClip = scoreClip;
        ballView.groundTouchClip = groundTouchClip;
    }


    /// <summary>
    /// Listner function which adds points to the score
    /// it Has been subscribed to OnCOllisionWithPlayer event in ball view.
    /// </summary>
    /// <param name="sender">Sender object who fired the event.</param>
    /// <param name="e">Arguments passed when event was fired.</param>
    private void AddPoints(object sender, EventArgs e)
    {
        GamePageManager.instance.AddPoints(1);
    }

    /// <summary>
    /// Listner function which reduces lives of the player
    /// it Has been subscribed to OnCOllisionWithGround event in ball view.
    /// </summary>
    /// <param name="sender">Sender object who fired the event.</param>
    /// <param name="e">Arguments passed when event was fired.</param>
    private void ReduceLives(object sender, EventArgs e)
    {
        GamePageManager.instance.ReduceLives();
    }

    #endregion
}
