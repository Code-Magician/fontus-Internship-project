using UnityEngine;

public class PlayerController
{
    #region PUBLIC FIELDS

    /// <summary>
    /// Stores the Refernce of PlayerView.
    /// </summary>
    private PlayerView view;
    /// <summary>
    /// Stores the Reference of PlayerModel.
    /// </summary>
    private PlayerModel model;

    #endregion


    #region PRIVATE FIELD GETTERS

    public PlayerView View { get => view; }
    public PlayerModel Model { get => model; }

    #endregion


    #region PUBLIC METHODS

    /// <summary>
    /// PlayerController Constructor. Takes the reference of playerview and playermodel and sets in respective variables to make the MVC Architecture work.
    /// </summary>
    /// <param name="_view">Reference to PlayerView</param>
    /// <param name="_model">Reference to PlayerModel</param>
    public PlayerController(PlayerView _view, PlayerModel _model)
    {
        model = _model;
        view = _view;

        model.SetPlayerController(this);
        view.SetPlayerController(this);
    }

    /// <summary>
    /// Adds upward force of magnitude provided to player rigidbody.
    /// </summary>
    public void PlayerJump()
    {
        AudioManager.instance.PlaySfx(model.jumpClip, 1f);
        view.GetRigidBody.AddForce(Vector2.up * model.jumpForce);
    }

    /// <summary>
    /// Moves the player rigibody with the movementSpeed provided.
    /// </summary>
    /// <param name="multiplier">if it's value is positive then player move towards right. if value is negative then player moves towards left</param>
    public void Move(int multiplier)
    {
        Vector2 newVelocity = new Vector2(multiplier * model.movementSpeed, view.GetRigidBody.velocity.y);
        view.GetRigidBody.velocity = newVelocity;
    }

    /// <summary>
    /// Stops the movement of the player in x direction.
    /// </summary>
    public void StopMovementInX()
    {
        Vector2 newVelocity = new Vector2(0, view.GetRigidBody.velocity.y);
        view.GetRigidBody.velocity = newVelocity;
    }

    #endregion
}
