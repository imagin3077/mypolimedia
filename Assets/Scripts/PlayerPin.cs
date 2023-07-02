using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPin : MonoBehaviour
{
    public static int pin;
    public Text pinText;

    public GameObject winningGameUI;

    // Start is called before the first frame update
    void Start()
    {
        pin = PlayerPrefs.GetInt("pin", pin);
        pinText.text = "" + pin;
    }

    // Update is called once per frame
    void Update()
    {
        GetPin();
        WinningGame();
        pinText.text = "" + pin;
        Debug.Log("pin = " + pin);
    }

    public void GetPin()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            pin++;
            PlayerPrefs.SetInt("pin", pin);
            PlayerPrefs.Save();
        }

        //Update();
    }

    public void WinningGame()
    {
        if (pin == 18)
        {
            winningGameUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
