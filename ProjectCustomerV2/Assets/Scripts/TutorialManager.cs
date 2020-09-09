using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private PlayerController playerController = null;
    [SerializeField] private GameObject tutorialHolder = null;

    [TextArea(1, 6)]
    [SerializeField] private List<string> tutorialTexts = new List<string>();

    [SerializeField] private TextMeshProUGUI tutorialTextObject = null;

    private Animator animator = null;

    private int i = 0;
    private int textUntilAbleToMove = 3;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();

        tutorialTextObject.text = tutorialTexts[i];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && i < tutorialTexts.Count - 1)
        {
            changeText();
        }
    }

    private void changeText()
    {
        i++;
        tutorialTextObject.text = tutorialTexts[i];

        if (i < textUntilAbleToMove)
        {
            handleMovement(false);
        }
        else
        {
            handleMovement(true);
        }

        if (i >= tutorialTexts.Count - 1)
        {
            animator.SetTrigger("ExitTutorial");
        }
    }

    private void handleMovement(bool active)
    {
        playerController.enabled = active;
    }
}
