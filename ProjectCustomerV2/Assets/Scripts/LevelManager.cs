using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private TimeTracker timeTracker = null;

    public int timeTimerIsVisible = 30;

    public int timeForNewLevel = 300;

    [SerializeField] private Button startButton = null;

    void Start()
    {
        timeTracker = FindObjectOfType<TimeTracker>();

        LoadButton();
    }

    private void LoadButton()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void loadSceneWrapper()
    {
        StartCoroutine(LoadScene());
    }
}
