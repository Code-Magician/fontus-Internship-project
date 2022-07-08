using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HomePageManager : MonoBehaviour
{
    #region PRIVATE FUNCTIONS

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
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

    /// <summary>
    /// Exits the game in both application build mode and editor mode.
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #endregion
}
