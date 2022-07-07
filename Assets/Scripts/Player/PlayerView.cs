using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController controller;

    public void SetPlayerController(PlayerController _controller)
    {
        controller = _controller;
    }
}
