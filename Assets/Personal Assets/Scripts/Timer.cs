using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject WinScreen;
    private float StartTime;
    private bool finished = false;

    void Start()
    {
        StartTime = Time.time;
    }

    void Update()
    {
        if (finished)
            return;
        float t = Time.time - StartTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = $"{minutes}:{seconds}";
    }

    public void Finish()
        {
        finished = true;
        timerText.color = Color.red;
        WinScreen.SetActive(true);
        }
}
