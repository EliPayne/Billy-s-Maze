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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerHolder.currentTime = TimerHolder.currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(TimerHolder.currentTime);
        timerText.text = time.ToString(@"mm\:ss\:ff");

    }

}
