using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoard = null;
    [SerializeField] private TextMeshProUGUI trashScore = null;
    [SerializeField] private GameObject levelUI = null;
    private Animator animator = null;

    [SerializeField] private Toggle upgrade1;
    [SerializeField] private Toggle upgrade2;
    [SerializeField] private Toggle upgrade3;

    public bool boughtFirstUpgrade = false;
    public bool boughtSecondUpgrade = false;
    public bool boughtThirdUpgrade = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void handleScoreboard(bool activate, float trashScore)
    {
        scoreBoard.SetActive(activate);
        levelUI.SetActive(false);

        animator.SetTrigger("HideAll");

        updateTrashScore(trashScore);

        checkUpgrades();
    }

    public void updateTrashScore(float score)
    {
        trashScore.text = score.ToString();
    }

    private void checkUpgrades()
    {
        if (boughtFirstUpgrade)
            upgrade1.isOn = true;
        if (boughtSecondUpgrade)
            upgrade2.isOn = true;
        if (boughtThirdUpgrade)
            upgrade3.isOn = true;
    }
}
