using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerSettings playerSettings = null;
    private PlayerStats playerStats = null;
    private UIManager uiManager = null;
    private AchievementTracker achievementTracker = null;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerSettings = GetComponent<PlayerSettings>();
        uiManager = FindObjectOfType<UIManager>();
        achievementTracker = FindObjectOfType<AchievementTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SmallTrash"))
        {
            TrashController instance = other.gameObject.GetComponent<TrashController>();
            StartCoroutine(instance.handleDeactivation(playerSettings.pickupTime));

            if ((playerStats.trashAmount + playerSettings.smallTrash) <= playerSettings.maxCapacity)
            {
                achievementTracker.newTrashCollectedRecord(playerSettings.smallTrash);
                playerStats.trashAmount += playerSettings.smallTrash;
                uiManager.updateStats(uiManager.trashCounter, playerStats.trashAmount);
            }
            else
            {
                Debug.Log("Your ship is full! Return to base");
                playerStats.trashAmount = playerSettings.maxCapacity;
            }
        }

        if (other.gameObject.CompareTag("BigTrash"))
        {
            TrashController instance = other.gameObject.GetComponent<TrashController>();
            StartCoroutine(instance.handleDeactivation(playerSettings.pickupTime));

            if ((playerStats.trashAmount + playerSettings.bigTrash) <= playerSettings.maxCapacity)
            {
                achievementTracker.newTrashCollectedRecord(playerSettings.bigTrash);
                playerStats.trashAmount += playerSettings.bigTrash;
                uiManager.updateStats(uiManager.trashCounter, playerStats.trashAmount);
            }
            else
            {
                Debug.Log("Your ship is full! Return to base");
                playerStats.trashAmount = playerSettings.maxCapacity;
            }
        }
    }
}