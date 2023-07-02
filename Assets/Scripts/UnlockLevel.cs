using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    public int level2Unlock = 0;
    private int koinDibutuhkan = 6;
    public GameObject levelLocked;
    public GameObject LevelUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        level2Unlock = PlayerPrefs.GetInt("leveldibuka");
        PlayerPrefs.GetInt("pin", PlayerPin.pin);
        levelLocked.SetActive(false);
        LevelUnlocked.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UnlockLevel2();
    }

    public void UnlockLevel2()
    {
        if (PlayerPrefs.GetInt("pin", PlayerPin.pin) >= koinDibutuhkan )
        {
            PlayerPrefs.SetInt("leveldibuka", 1);
            PlayerPrefs.Save();
            LevelUnlocked.SetActive(true);
            levelLocked.SetActive(false);
            level2Unlock = 1;
        }
        else
        {
            LevelUnlocked.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (level2Unlock == 0)
        {
            levelLocked.SetActive(true);
        }
        else if (level2Unlock == 1)
        {
            levelLocked.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        levelLocked.SetActive(false);
    }
}
