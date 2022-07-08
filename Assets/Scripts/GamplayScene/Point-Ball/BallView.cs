using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public event EventHandler OnCollision;
    public float ballSpeed;

    private void Update()
    {
        transform.Translate(Vector2.down * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnCollision?.Invoke(this, EventArgs.Empty);
        }
        Destroy(this.gameObject);
    }
}
