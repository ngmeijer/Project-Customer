using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoard = null;
    [SerializeField] private TextMeshProUGUI trashScore = null;
    [SerializeField] private GameObject levelUI = null;
    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void handleScoreboard(bool activate, int trashScore)
    {
        scoreBoard.SetActive(activate);
        levelUI.SetActive(false);

        animator.SetTrigger("HideAll");

        updateTrashScore(trashScore);
    }

    public void updateTrashScore(int score)
    {
        trashScore.text = score.ToString();
    }
}
