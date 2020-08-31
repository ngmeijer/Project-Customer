using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator canvasAnimator = null;
    [SerializeField] private float sceneTransitionTime = 1f;

    public IEnumerator StartGame()
    {
        canvasAnimator.SetTrigger("ProceedToLevel");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield break;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
