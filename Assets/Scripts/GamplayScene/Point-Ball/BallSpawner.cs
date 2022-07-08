using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] BallView ball;
    [SerializeField] CircleCollider2D ballCollider;
    [SerializeField] float minBallSpeed, maxBallSpeed;
    [SerializeField] AudioClip scoreClip, groundTouchClip;

    private void Start()
    {
        GamePageManager.instance.OnStartTimerOver += PeriodicBallSpawning;
    }

    public void PeriodicBallSpawning(object sender, EventArgs e)
    {
        GamePageManager.instance.OnStartTimerOver -= PeriodicBallSpawning;
        InvokeRepeating("SpawnBall", 0, 3f);
    }

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

    private void AddPoints(object sender, EventArgs e)
    {
        GamePageManager.instance.AddPoints(1);
    }

    private void ReduceLives(object sender, EventArgs e)
    {
        GamePageManager.instance.ReduceLives();
    }
}
