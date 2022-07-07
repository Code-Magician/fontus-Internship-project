using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerView view;
    public PlayerModel model;


    public PlayerController(PlayerView _view, PlayerModel _model)
    {
        model = _model;
        view = _view;

        model.SetPlayerController(this);
        view.SetPlayerController(this);
    }

    public void PlayerJump()
    {
        view.GetRigidBody.AddForce(Vector2.up * model.jumpForce);
    }

    public void Move(int multiplier)
    {
        Vector2 newVelocity = new Vector2(multiplier * model.movementSpeed, view.GetRigidBody.velocity.y);
        view.GetRigidBody.velocity = newVelocity;
    }
}
