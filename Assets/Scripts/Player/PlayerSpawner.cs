using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerView player;


    private void Start()
    {
        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        PlayerModel model = new PlayerModel();
        PlayerView view = Instantiate<PlayerView>(player);
        PlayerController controller = new PlayerController(view, model);
    }
}
