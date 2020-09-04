﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    private LevelManager levelManager = null;
    private UIManager uiManager = null;

    public float timer = 0;
    [SerializeField] private int timeTimerIsVisible = 30;

    [SerializeField] private int timeForNewLevel = 300;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        levelManager = GetComponent<LevelManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > (timeForNewLevel - timeTimerIsVisible))
        {
            int timeLeft = timeForNewLevel - (int)timer;
            uiManager.showTimer(timeLeft);

            if (timer >= timeForNewLevel)
            {
                levelManager.loadNextLevel();
            }
        }
    }
}
