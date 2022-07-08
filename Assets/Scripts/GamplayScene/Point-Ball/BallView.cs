using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public event EventHandler OnCollision;
    public float ballSpeed;
    public AudioClip scoreClip;
    public AudioClip groundTouchClip;

    private void Update()
    {
        transform.Translate(Vector2.down * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySfx(scoreClip, 1f);
            OnCollision?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            AudioManager.instance.PlaySfx(groundTouchClip, 1f);
        }
        Destroy(this.gameObject);
    }
}
