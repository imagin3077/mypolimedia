using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int levelToLoad;

    public void NewGame(string SceneName)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneName);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("saved"))
        {
            levelToLoad = PlayerPrefs.GetInt("saved", 1);
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Keluar Game");
    }
}
