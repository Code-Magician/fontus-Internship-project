using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerView view;
    private PlayerModel model;


    public PlayerController(PlayerView _view, PlayerModel _model)
    {
        model = _model;
        view = _view;

        model.SetPlayerController(this);
        view.SetPlayerController(this);
    }
}
