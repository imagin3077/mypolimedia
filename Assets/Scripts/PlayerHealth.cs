using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 3;
    public GameObject[] hearts;

    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        health = hearts.Length;
        health = PlayerPrefs.GetInt("health", health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy(hearts[0].gameObject);
            Destroy(hearts[1].gameObject);
            Destroy(hearts[2].gameObject);
        }
        else if (health < 2)
        {
            Destroy(hearts[1].gameObject);
            Destroy(hearts[2].gameObject);
        }
        else if (health < 3)
        {
            Destroy(hearts[2].gameObject);
        }

        Debug.Log("nyawa = " + health);
        
        GameOver();
    }

    public void ReduceHealth()
    {
        if (health >= 1)
        {
            health -= 1;
            //Destroy(hearts[health].gameObject);
        }
        PlayerPrefs.SetInt("health", health);
    }

    public void GameOver()
    {
        if (health == 0)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
