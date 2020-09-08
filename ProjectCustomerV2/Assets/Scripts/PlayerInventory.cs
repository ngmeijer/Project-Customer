using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerSettings playerSettings = null;
    private PlayerStats playerStats = null;
    private UIManager uiManager = null;
    private AchievementTracker achievementTracker = null;

    public float progress;
    private float timePresent = 0;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerSettings = GetComponent<PlayerSettings>();
        uiManager = FindObjectOfType<UIManager>();
        achievementTracker = FindObjectOfType<AchievementTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SmallTrash") || other.gameObject.CompareTag("Trash"))
        {
            if ((playerStats.trashAmount + playerSettings.smallTrash) <= playerSettings.maxCapacity)
            {
                //achievementTracker.newTrashCollectedRecord(playerSettings.smallTrash);
                playerStats.trashAmount += playerSettings.smallTrash;
                uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false);
            }
            else
            {
                playerStats.trashAmount = playerSettings.maxCapacity;
                uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false);
                uiManager.handleShipFullNotif(true);
            }
        }

        if (other.gameObject.CompareTag("BigTrash"))
        {
            TrashController instance = other.gameObject.GetComponent<TrashController>();
            StartCoroutine(instance.handleDeactivation(playerSettings.pickupTime));

            if ((playerStats.trashAmount + playerSettings.bigTrash) <= playerSettings.maxCapacity)
            {
                //achievementTracker.newTrashCollectedRecord(playerSettings.bigTrash);
                playerStats.trashAmount += playerSettings.bigTrash;
                uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false);
            }
            else
            {
                playerStats.trashAmount = playerSettings.maxCapacity;
                uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false);
                uiManager.handleShipFullNotif(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            TrashController instance = other.gameObject.GetComponent<TrashController>();
            StartCoroutine(instance.handleDeactivation(playerSettings.pickupTime));

            timePresent += Time.deltaTime;
            progress = timePresent / playerSettings.pickupTime;

            uiManager.showProgressBar(progress);

            if (progress >= 1)
            {
                timePresent = 0;
                uiManager.hideProgressbar();
            }
        }
    }
}