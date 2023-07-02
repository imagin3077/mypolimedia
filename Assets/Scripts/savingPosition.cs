using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savingPosition : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("saved") == 1)
        {
            LoadPos();
        }

    }


   public void SavePos()
    {
        var xPos = player.transform.position.x;
        var yPos = player.transform.position.y;
        PlayerPrefs.SetFloat("x", xPos);
        PlayerPrefs.SetFloat("y", yPos);
        PlayerPrefs.SetInt("saved", 1);
        PlayerPrefs.Save();
    }

    public void LoadPos()
    {
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
    }
}
