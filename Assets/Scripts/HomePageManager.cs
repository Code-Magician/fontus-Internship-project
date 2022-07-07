using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{
    public void GotoGameScene()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
