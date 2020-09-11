using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerSettings playerSettings = null;
    private PlayerStats playerStats = null;
    private PlayerController playerController = null;
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
        playerController = GetComponent<PlayerController>();
        uiManager = FindObjectOfType<UIManager>();
        achievementTracker = FindObjectOfType<AchievementTracker>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerSettings.canCollectTrash)
        {
            if (other.gameObject.CompareTag("Trash"))
            {
                if ((playerStats.trashAmount + playerSettings.trashValue) <= playerSettings.maxCapacity)
                {
                    timePresent += Time.deltaTime;
                    progress = timePresent / playerSettings.pickupTime;

                    uiManager.showProgressBar(progress);

                    //playerController.enabled = false;

                    if (progress >= 1)
                    {
                        //if (playerSettings.lockMovementWhileTrashing)
                        //    playerController.enabled = true;
                        achievementTracker.newTrashCollectedRecord(playerSettings.trashValue);
                        playerStats.trashAmount += playerSettings.trashValue;
                        other.gameObject.SetActive(false);
                        uiManager.hideProgressbar();
                        timePresent = 0;
                    }

                    uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false, true);
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

            if (playerStats.trashAmount >= playerSettings.maxCapacity)
            {
                //uiManager.handleShipFullNotif(true);
            }
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