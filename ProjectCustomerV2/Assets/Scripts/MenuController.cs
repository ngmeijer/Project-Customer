using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //[SerializeField] private Animator canvasAnimator = null;
    [SerializeField] private float sceneTransitionTime = 1f;

    public void startGameWrapper()
    {
        StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        //canvasAnimator.SetTrigger("ProceedToLevel");

        yield return new WaitForSeconds(sceneTransitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield break;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
