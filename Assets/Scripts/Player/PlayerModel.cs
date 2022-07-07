using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private PlayerController controller;
    public float jumpForce;
    public float movementSpeed;
    /// <summary>
    /// The amount of time (in seconds) the touch should be holded to make the player move.
    /// </summary>
    public float touchHoldTime;
    /// <summary>
    /// We pass the percentage here. if the swipe length is equal to or greater then the validSwipePercent amount of ScreenHeight then it's considered a valid swipe.
    /// </summary>
    public float validSwipePercent;

    public PlayerModel(float _jumpForce, float _movementSpeed, float _validSwipePercent, float _touchHoldTime)
    {
        jumpForce = _jumpForce;
        movementSpeed = _movementSpeed;
        validSwipePercent = _validSwipePercent;
        touchHoldTime = _touchHoldTime;
    }

    public void SetPlayerController(PlayerController _controller)
    {
        controller = _controller;
    }
}
