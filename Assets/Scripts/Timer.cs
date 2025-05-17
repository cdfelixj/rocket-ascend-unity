using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    bool isRunning = true; // Add this flag
    int minutes;
    int seconds;


    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            minutes = Mathf.FloorToInt(elapsedTime / 60);
            seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "You finished in " + elapsedTime.ToString() + " Seconds, Wait for Next Level";
        }
    }

    public void StopTimer() // Add this method
    {
        isRunning = false;
    }
}
