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
    [SerializeField] private float timePresent = 0;
    private TrashController instance;
    private Coroutine pickupCoroutine;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerSettings = GetComponent<PlayerSettings>();
        uiManager = FindObjectOfType<UIManager>();
        achievementTracker = FindObjectOfType<AchievementTracker>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            if ((playerStats.trashAmount + playerSettings.trashValue) <= playerSettings.maxCapacity)
            {
                timePresent += Time.deltaTime;
                progress = timePresent / playerSettings.pickupTime;

                uiManager.showProgressBar(progress);

                if (progress >= 1)
                {
                    achievementTracker.newTrashCollectedRecord(playerSettings.trashValue);
                    playerStats.trashAmount += playerSettings.trashValue;
                    other.gameObject.SetActive(false);
                    uiManager.hideProgressbar();
                    timePresent = 0;
                }

                uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false);
            }
            else
            {
                playerStats.trashAmount = playerSettings.maxCapacity;
            }
        }
        else
        {
            uiManager.hideProgressbar();
            timePresent = 0;
        }

        if(playerStats.trashAmount >= playerSettings.maxCapacity)
        {
            uiManager.handleShipFullNotif(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            uiManager.hideProgressbar();
            timePresent = 0;
        }
    }
}