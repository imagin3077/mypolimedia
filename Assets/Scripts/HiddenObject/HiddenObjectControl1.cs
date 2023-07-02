using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HiddenObjectControl1 : MonoBehaviour
{
    [Space]
    public GameObject itemParent;
    public SaveItemPos saveItemPos;

    [Space]
    public int totalItem;
    //public Text totalItemText;

    [Space]
    public GameObject winPanel;
    public GameObject losePanel;

    [Space]
    //public TimerSetting timer;
    public bool timerAktif = true;

    float currentTime;
    public float startingTime = 60f;
    public Text timerText;

    [Space]
    public int wrongChance = 3;
    public Text wrongChanceText;

    [Space]
    public GameObject[] stars;

    public int menang = 0;
    public int kalah = 0;

    [Space]
    public AudioSource bgMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        bgMusic.Play();
        RandomItemPosition();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimer();
        WinGame();
        LoseGame();
    }

    void RandomItemPosition()
    {
        int randomSave = Random.Range(0, saveItemPos.saveItemPos.Count);

        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            itemParent.transform.GetChild(i).transform.localPosition = 
                saveItemPos.saveItemPos[randomSave].itemPos[i];
        }
        Debug.Log(randomSave);
    }

    public void WinGame()
    {

        if (totalItem == 0 && menang == 0)
        {
            winMusic.PlayDelayed(0.4f);
            winPanel.SetActive(true);
            timerAktif = false;
            menang = 1;
            bgMusic.Stop();
            CheckWin();
        }
    }

    public void CheckWin()
    {
        PlayerPin.pin += 3;
        PlayerPrefs.SetInt("pin", PlayerPin.pin);
        PlayerPrefs.Save();
    }


    public void LoseGame()
    { 

        if (timerAktif && currentTime == 0 && kalah == 0)
        {
            loseMusic.PlayDelayed(0.4f);
            losePanel.SetActive(true);
            timerAktif = false;
            kalah = 1;
            bgMusic.Stop();
            CheckLose();
        } 
        
        if (wrongChance == 0 && kalah == 0)
        {
            loseMusic.PlayDelayed(0.4f);
            losePanel.SetActive(true);
            timerAktif = false;
            kalah = 1;
            bgMusic.Stop();
            CheckLose();
        }
    }

    public void CheckLose()
    {
        PlayerHealth.health--;
        PlayerPrefs.SetInt("health", PlayerHealth.health);
        PlayerPrefs.Save();
    }

    public void SetTimer()
    {
        if (timerAktif)
        {
            currentTime -= 1 * Time.deltaTime;
            //timeLeft = startingTime - currentTime;
            timerText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }
        //Debug.Log(currentTime);
    }
}
