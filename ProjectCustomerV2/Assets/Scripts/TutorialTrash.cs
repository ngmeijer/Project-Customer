using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrash : MonoBehaviour
{
    private TutorialManager tutorialManager = null;

    private void Start()
    {
        tutorialManager = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(triggerNextPart());
        }
    }

    private IEnumerator triggerNextPart()
    {
        yield return new WaitForSeconds(1);

        tutorialManager.goToBase = true;

        yield return new WaitForSeconds(2);

        yield break;
    }
}
