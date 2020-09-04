using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private TimeTracker timeTracker = null;

    public int timeTimerIsVisible = 30;

    public int timeForNewLevel = 300;

    private void Start()
    {
        timeTracker = FindObjectOfType<TimeTracker>();
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
