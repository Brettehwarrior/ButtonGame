using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;
    public Text currentTimeText;
    
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

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        
        currentTimeText.text = "You lasted " + time.ToString(@"mm\:ss") + ".";

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
