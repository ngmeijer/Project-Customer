using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private PlayerController playerController = null;
    private TrashGenerator[] trashGenerators;
    private TimeTracker timeTracker = null;
    [SerializeField] private GameObject tutorialHolder = null;

    [TextArea(1, 6)]
    [SerializeField] private List<string> tutorialTexts = new List<string>();

    [SerializeField] private TextMeshProUGUI tutorialTextObject = null;

    [SerializeField] private GameObject trashExample = null;

    private Animator canvasAnim = null;
    [SerializeField] private Animator tutorialCamAnim = null;
    [SerializeField] private GameObject mainCamera = null;
    [SerializeField] private GameObject tutorialCamera = null;

    [SerializeField] private GameObject pickupBar = null;

    private int currentText = 0;

    public bool goToBase = false;
    private bool regainCamControl = false;
    public bool playTutorial = false;

    private void Start()
    {
        if (playTutorial)
        {
            playerController = FindObjectOfType<PlayerController>();
            canvasAnim = GetComponent<Animator>();
            trashGenerators = FindObjectsOfType<TrashGenerator>();
            timeTracker = FindObjectOfType<TimeTracker>();
            handleMovement(false);

            for (int i = 0; i < trashGenerators.Length; i++)
            {
                trashGenerators[i].enabled = false;
            }

            tutorialTextObject.text = tutorialTexts[currentText];

            mainCamera.SetActive(false);
            tutorialCamera.SetActive(true);
        }
    }

    private void Update()
    {
        if (playTutorial)
        {
            if (currentText < tutorialTexts.Count - 1)
            {
                if ((Input.GetKeyDown(KeyCode.Space) || (goToBase)) || (regainCamControl))
                {
                    changeText();
                }
            }
        }
    }

    private void changeText()
    {
        currentText++;
        Debug.Log(currentText);
        switch (currentText)
        {
            case 0:
                break;
            case 1:
                tutorialCamAnim.SetTrigger("ShowBoat");
                break;
            case 2:
                trashExample.SetActive(true);
                break;
            case 3:
                tutorialCamAnim.SetTrigger("FocusOnTrash");
                break;
            case 4:
                canvasAnim.SetTrigger("PauseTutorial");
                tutorialHolder.SetActive(false);
                mainCamera.SetActive(true);
                tutorialCamera.SetActive(false);
                handleMovement(true);
                if (goToBase)
                {
                    currentText++;
                    goToBase = false;
                }
                break;
            case 5:
                canvasAnim.SetTrigger("ResumeTutorial");
                StartCoroutine(baseTutorial());
                break;
            case 6:
                tutorialCamera.SetActive(false);
                mainCamera.SetActive(true);
                break;
        }
        tutorialTextObject.text = tutorialTexts[currentText];
    }

    private IEnumerator baseTutorial()
    {
        yield return new WaitForSeconds(2);
        tutorialCamera.SetActive(true);
        mainCamera.SetActive(false);
        tutorialCamAnim.SetTrigger("ShowBase");

        yield return new WaitForSeconds(3);

        canvasAnim.SetTrigger("PauseTutorial");

        tutorialCamera.SetActive(false);
        mainCamera.SetActive(true);

        yield break;
    }

    private IEnumerator finishTutorial()
    {
        mainCamera.SetActive(true);
        tutorialCamera.SetActive(false);

        for (int i = 0; i < trashGenerators.Length; i++)
        {
            trashGenerators[i].enabled = true;
        }

        handleMovement(true);

        canvasAnim.SetTrigger("ExitTutorial");

        timeTracker.startTime = true;

        yield break;
    }

    private void handleMovement(bool active)
    {
        playerController.enabled = active;
    }
}
