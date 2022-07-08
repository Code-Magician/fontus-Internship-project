using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region PRIVATE FIELDS

    /// <summary>
    /// Gets the playerview of the player prefab.
    /// </summary>
    [SerializeField] PlayerView player;

    /// <summary>
    /// Gets the jump force magnitude from the inspector
    /// </summary>
    [SerializeField] float jumpForce;

    /// <summary>
    /// Gets the movement speed from the inspector.
    /// </summary>
    [SerializeField] float movementSpeed;

    /// <summary>
    /// Gets the valid swipe percentage from the inspector.
    /// </summary>
    [SerializeField] float validSwipePercent;

    /// <summary>
    /// Gets the touch hold time from the inspector.
    /// </summary>
    [SerializeField] float touchHoldTime;

    /// <summary>
    /// Player jump sound clip.
    /// </summary>
    [SerializeField] AudioClip jumpClip;

    #endregion


    #region PRIVATE METHODS

    private void Start()
    {
        SpawnPlayer();
    }

    #endregion


    #region PUBLIC METHODS

    /// <summary>
    /// Makes new instance of Player Model and sets all player properties in Player Model.
    /// Instantiates the player using player prefab. 
    /// Makes new instance of Player Controller and sets reference of view and model in Player controller.
    /// </summary>
    public void SpawnPlayer()
    {
        PlayerModel model = new PlayerModel(_jumpForce: jumpForce,
        _movementSpeed: movementSpeed,
        _validSwipePercent: validSwipePercent,
        _touchHoldTime: touchHoldTime,
        _jumpClip: jumpClip);

        PlayerView view = Instantiate<PlayerView>(player);
        PlayerController controller = new PlayerController(view, model);
    }

    #endregion
}
