using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    public Text timerText;
    public float waktu;

    void Start()
    {

    }

    public void Update()
    {
        SetText();
    }

    void SetText()
    {
        int Menit = Mathf.FloorToInt(waktu / 60);
        int Detik = Mathf.FloorToInt(waktu % 60);
        timerText.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }

}
