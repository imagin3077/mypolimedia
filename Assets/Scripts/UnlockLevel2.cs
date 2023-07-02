using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel2 : MonoBehaviour
{
    public int level3Unlock = 0;
    private int koinDibutuhkan = 12;
    public GameObject levelLocked;
    public GameObject LevelUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        level3Unlock = PlayerPrefs.GetInt("leveldibuka2");
        PlayerPrefs.GetInt("pin", PlayerPin.pin);
        levelLocked.SetActive(false);
        LevelUnlocked.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UnlockLevel3();
    }

    public void UnlockLevel3()
    {
        if (PlayerPrefs.GetInt("pin", PlayerPin.pin) >= koinDibutuhkan )
        {
            PlayerPrefs.SetInt("leveldibuka2", 1);
            PlayerPrefs.Save();
            LevelUnlocked.SetActive(true);
            levelLocked.SetActive(false);
            level3Unlock = 1;
        }
        else
        {
            LevelUnlocked.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (level3Unlock == 0)
        {
            levelLocked.SetActive(true);
        }
        else if (level3Unlock == 1)
        {
            levelLocked.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        levelLocked.SetActive(false);
    }
}
