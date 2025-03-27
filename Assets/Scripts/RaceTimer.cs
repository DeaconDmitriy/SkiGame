using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    bool timerRunning = false;
    private float raceTime = 0;
    private void OnEnable()
    {
        GameManager.RaceStart += StartRaceTimer;
        GameManager.RaceFinish += StopRaceTimer;
    }
    private void OnDisable()
    {
        GameManager.RaceStart -= StartRaceTimer;
        GameManager.RaceFinish -= StopRaceTimer;
    }
    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }

    private void StartRaceTimer()
    {
        timerRunning = true;
        Debug.Log("race started");
    }
    private void StopRaceTimer()
    {
        timerRunning = false;
        Debug.Log("Race finished! Race time: " + raceTime);
    }
}
