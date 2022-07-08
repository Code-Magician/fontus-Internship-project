using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{
    #region PRIVATE FUNCTIONS

    private void Awake()
    {
        AudioManager.instance.PlayBgMusic(0.5f);
    }

    #endregion


    #region PUBLIC METHODS

    /// <summary>
    /// loads the scene using the name of the scene.
    /// </summary>
    /// <param name="sceneName">scene name (in string) to be loaded.</param>
    public void GotoGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}