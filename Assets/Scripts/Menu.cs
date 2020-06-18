using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void ClosePanel(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Debug.Log("Game quit...");
        Application.Quit();
    }
}
