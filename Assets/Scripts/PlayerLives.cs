using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLives : MonoBehaviour
{
    public static int lives = 3;
    //private HiddenObjectControl1 playerLives;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives", lives);
    }

    void Update()
    {
        UpdateHearts();
        ReduceLives();
        Debug.Log("nyawa = " + lives);
    }

    public void UpdateHearts()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < lives; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void ReduceLives()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lives--;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            lives++;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.Save();
        }

        //playerLives.LoseGame();

        UpdateHearts();

        if (lives == 0)
        {
            //gameOverCanvas.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    
}
