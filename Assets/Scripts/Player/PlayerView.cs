using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private PlayerController controller;


    Touch startTouch, endTouch;
    float pressTime = 0;
    bool isGrounded;


    public Rigidbody2D GetRigidBody
    {
        get => rb;
    }

    private void Update()
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

        bool validLength = Vector2.Distance(startTouch.position, endTouch.position) >= (Screen.height * controller.model.validSwipePercent / 100);
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
        }

        if (pressTime >= controller.model.touchHoldTime)
        {
            Vector2 touchPos = touch.position;

            if (touchPos.x >= Screen.width / 2f)
                controller.Move(1);
            else
                controller.Move(-1);
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


    public void SetPlayerController(PlayerController _controller)
    {
        controller = _controller;
    }
}
