using System;
using UnityEngine;

public class BallView : MonoBehaviour
{
    #region PUBLCI FIELDS

    /// <summary>
    /// Event fired when Ball collides with player.
    /// </summary>
    public event EventHandler OnCollisionWithPlayer;

    /// <summary>
    /// Event fired when Ball collides with ground.
    /// </summary>
    public event EventHandler OnCollisionWithGround;

    /// <summary>
    /// Downward speed of moving ball
    /// </summary>
    public float ballSpeed;

    /// <summary>
    /// Audioclip played when ball collides with player.
    /// </summary>
    public AudioClip scoreClip;

    /// <summary>
    /// Audioclip played when ball collides with ground.
    /// </summary>
    public AudioClip groundTouchClip;

    #endregion


    #region PRIVATE FUNCTIONS

    private void Update()
    {
        transform.Translate(Vector2.down * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySfx(scoreClip, 1f);
            OnCollisionWithPlayer?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            AudioManager.instance.PlaySfx(groundTouchClip, 1f);
            OnCollisionWithGround?.Invoke(this, EventArgs.Empty);
        }
        Destroy(this.gameObject);
    }

    #endregion
}
