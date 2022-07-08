using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    #region PRIVATE FIELDS

    /// <summary>
    /// Stores the reference of Player Controller.
    /// </summary>
    private PlayerController controller;

    /// <summary>
    /// Gets the reference of player rigidbody from the inspector.
    /// </summary>
    [SerializeField] Rigidbody2D rb;


    Touch startTouch, endTouch;
    float pressTime = 0;
    bool isGrounded;

    #endregion


    #region PRIVATE FIELD GETTERS

    /// <summary>
    /// Getter for rigidbody of player
    /// </summary>
    public Rigidbody2D GetRigidBody
    {
        get => rb;
    }

    #endregion


    #region PRIVATE METHODS

    private void Update()
    {
        HandlePlayerInput();
    }

    /// <summary>
    /// Foeach touch input this function performs movement of player and jumping of player if it satisfies the valid input conditions.
    /// </summary>
    private void HandlePlayerInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (i == 0 && !Movement(i))
            {
                if (isGrounded && IsValidSwipe(i))
                {
                    controller.PlayerJump();
                }
            }
            else
            {
                if (IsValidSwipe(i))
                {
                    controller.PlayerJump();
                }
            }

        }
    }


    /// <summary>
    /// chekcs if the swipe is valid up swipe or not.
    /// swipe is valid up swipe if it's start y position is less then ending y position.
    /// swipe length is greater or equal to provided length and
    /// swipe length in vertical direction is greater then swipe length in horizontal direction.
    /// </summary>
    /// <param name="index">it's the Touch index.</param>
    /// <returns></returns>
    private bool IsValidSwipe(int index)
    {
        Touch touch = Input.GetTouch(index);
        if (touch.phase == TouchPhase.Began)
        {
            startTouch = touch;
            endTouch = touch;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            endTouch = touch;
        }

        bool validLength = Vector2.Distance(startTouch.position, endTouch.position) >= (Screen.height * controller.Model.validSwipePercent / 100);
        bool isUpSwipe = (Mathf.Abs(startTouch.position.x - endTouch.position.x) < Mathf.Abs(startTouch.position.y - endTouch.position.y)) &&
                        (startTouch.position.y < endTouch.position.y);


        if (validLength && isUpSwipe)
        {
            startTouch = endTouch;
            isGrounded = false;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Handles player movement.
    /// if the player touches on left side of screen then it makes player move to left and vice versa.
    /// the movement starts after touchHoldTime provided.
    /// when the player has tapped on the screen(touch phase is began).
    /// </summary>
    /// <param name="index">It's the Touch index.</param>
    /// <returns></returns>
    private bool Movement(int index)
    {
        Touch touch = Input.GetTouch(index);
        if (touch.phase == TouchPhase.Stationary)
        {
            pressTime += Time.deltaTime;
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            pressTime = 0;
            if (isGrounded) controller.StopMovementInX();
        }

        if (pressTime >= controller.Model.touchHoldTime)
        {
            Vector2 touchPos = touch.position;

            if (touchPos.x >= Screen.width / 2f)
                controller.Move(multiplier: 1);
            else
                controller.Move(multiplier: -1);
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    #endregion


    #region PUBLIC METHODS

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
