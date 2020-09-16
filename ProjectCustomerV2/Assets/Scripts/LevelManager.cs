using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private TimeTracker timeTracker = null;
    private AsyncOperation async;

    public int timeForNewLevel = 300;

    void Start()
    {
        timeTracker = FindObjectOfType<TimeTracker>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
            preloadScene();
    }

    private void preloadScene()
    {
        StartCoroutine(load());
    }

    private IEnumerator load()
    {
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        async.allowSceneActivation = false;

        yield return async;
    }

    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
