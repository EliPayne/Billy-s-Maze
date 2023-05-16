using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;   
    public float currentTime;
    bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.ToString(@"mm\:ss\:ff");
    }

    private void startTimer()
    {
        timerActive = true;
    }

    private void stopTimer()
    {
        timerActive = false;
    }
}
