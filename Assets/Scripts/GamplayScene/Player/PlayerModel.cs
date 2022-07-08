using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    #region PRIVATE FIELDS

    /// <summary>
    /// Stores Reference of PlayerController
    /// </summary>
    private PlayerController controller;

    #endregion


    #region PUBLIC FIELDS

    /// <summary>
    /// Stores Player jumpForce magnitude.
    /// </summary>
    public float jumpForce;

    /// <summary>
    /// Stores Player movementSpeed magnitude.
    /// </summary>
    public float movementSpeed;

    /// <summary>
    /// Stores the amount of time the player have to hold the screen to make that input a valid movement input.
    /// </summary>
    public float touchHoldTime;

    /// <summary>
    /// Stores the percentage amount which is used to check if the Swipe is valid or not.
    /// Let us assume this amount is 25%. then we calculate 25% of the screen height.
    /// if our swipe length will be greater then this calculated amount then it's considered a valid swipe else invalid.
    /// </summary>
    public float validSwipePercent;

    /// <summary>
    /// Stores player jump audio clip.
    /// </summary>
    public AudioClip jumpClip;

    #endregion


    #region  PUBLIC METHODS

    /// <summary>
    /// Constructor used to set the reference of the variables.
    /// </summary>
    /// <param name="_jumpForce">Reference to jump force magnitude.</param>
    /// <param name="_movementSpeed">Reference to movement speed magnitude.</param>
    /// <param name="_validSwipePercent">Reference to validSwipe percentage magnitude.</param>
    /// <param name="_touchHoldTime">Reference to touch hold time magnitude.</param>
    public PlayerModel(float _jumpForce, float _movementSpeed, float _validSwipePercent,
                float _touchHoldTime, AudioClip _jumpClip)
    {
        jumpForce = _jumpForce;
        movementSpeed = _movementSpeed;
        validSwipePercent = _validSwipePercent;
        touchHoldTime = _touchHoldTime;
        jumpClip = _jumpClip;
    }

    /// <summary>
    /// Used to set the playerController variable in this class.
    /// </summary>
    /// <param name="_controller">Reference to the player Controller</param>
    public void SetPlayerController(PlayerController _controller)
    {
        controller = _controller;
    }

    #endregion
}
