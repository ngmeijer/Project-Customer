using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    private LevelManager levelManager = null;
    private UIManager uiManager = null;
    private ScoreBoard scoreBoard = null;
    private PlayerStats playerStats = null;

    public float timer = 0;

    public bool startTime = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        levelManager = GetComponent<LevelManager>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        if (startTime)
            timer += Time.deltaTime;

        int timeLeft = levelManager.timeForNewLevel - (int)timer;

        uiManager.showTimer(timeLeft);

        if (timer >= levelManager.timeForNewLevel)
        {
            scoreBoard.handleScoreboard(true, playerStats.totalTrashCollected);
        }
    }
}
