using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : GameBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        _GM.ChangeGameState(GameManager.GameState.Playing);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
