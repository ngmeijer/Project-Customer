using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    private LevelManager levelManager = null;
    private UIManager uiManager = null;

    public float timer = 0;
    

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        levelManager = GetComponent<LevelManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > (levelManager.timeForNewLevel - levelManager.timeTimerIsVisible))
        {
            int timeLeft = levelManager.timeForNewLevel - (int)timer;
            uiManager.showTimer(timeLeft);

            if (timer >= levelManager.timeForNewLevel)
            {
                levelManager.ActivateScene();
            }
        }
    }
}
