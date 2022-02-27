using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;
    public TextMeshProUGUI currentTimeText;
    
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime + Time.deltaTime;

        }

        currentTimeText.text = GetTimeString();
    }

    public string GetTimeString()
    {
        return TimeSpan.FromSeconds(currentTime).ToString(@"mm\:ss");
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
