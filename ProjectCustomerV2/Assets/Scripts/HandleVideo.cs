using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HandleVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer tutorialPlayer = null;
    private float timer = 0;
    private bool videoHasFinished;
    private int secondsIdle = 0;
    private Vector3 tmpMousePosition;
    private int timeAllowedToBeIdle = 10;
    [SerializeField] private GameObject continueButton = null;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            StartCoroutine(checkTutorialEnd());
            timer = 0;
        }

        if (secondsIdle >= timeAllowedToBeIdle)
        {
            tutorialPlayer.Play();
            secondsIdle = 0;
        }
    }

    private IEnumerator checkTutorialEnd()
    {
        if (tutorialPlayer.isPlaying)
        {
            if (continueButton.activeInHierarchy)
                continueButton.SetActive(false);
            yield return null;
        }
        else
        {
            videoHasFinished = true;
            continueButton.SetActive(true);
            StartCoroutine(checkMouseMovement());
        }
        yield break;
    }

    private IEnumerator checkMouseMovement()
    {
        if (tmpMousePosition == Input.mousePosition)
        {
            secondsIdle++;
        }
        else
        {
            secondsIdle = 0;
        }
        tmpMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

        yield break;
    }
}
