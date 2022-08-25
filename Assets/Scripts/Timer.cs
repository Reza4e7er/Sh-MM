using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public bool TimerOn;
    float TimeScore;
    void Start()
    {
        TimerOn = true;
        TimeScore = 0f;
    }

    void Update()
    {
        if (TimerOn)
        {
            TimeScore += Time.deltaTime;
            UpdateTimer(TimeScore);
        }
        else
        {
            TimerOn = false;
            TimeScore = 0;
        }
    }
    public void UpdateTimer(float CurrentTime)
    {
        CurrentTime += 1;
        float minutes = Mathf.FloorToInt(CurrentTime / 60);
        float seconds = Mathf.FloorToInt(CurrentTime % 60);
        timer.text = string.Format("{0:00}:{1,00}", minutes, seconds);
    }
}
