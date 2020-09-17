using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private AsyncOperation async;

    public int timeForNewLevel = 300;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
            async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        else async = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

        preloadScene();
    }

    private void preloadScene()
    {
        StartCoroutine(load());
    }

    private IEnumerator load()
    {
        async.allowSceneActivation = false;

        yield return async;
    }

    public void ActivateScene()
    {
        Debug.Log(async);
        async.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}