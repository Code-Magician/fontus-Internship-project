using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] PlayerView player;
    [SerializeField] float jumpForce;
    [SerializeField] float movementSpeed;
    [SerializeField] float validSwipePercent;
    [SerializeField] float touchHoldTime;


    private void Start()
    {
        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        PlayerModel model = new PlayerModel(jumpForce, movementSpeed, validSwipePercent, touchHoldTime);
        PlayerView view = Instantiate<PlayerView>(player);
        PlayerController controller = new PlayerController(view, model);
    }

    public void RightMovementButton()
    {

    }

    public void LeftMovementButton()
    {

    }
}
