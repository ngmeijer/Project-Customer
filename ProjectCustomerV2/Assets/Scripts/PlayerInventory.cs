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
    [SerializeField] private Material arrowMaterial = null;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerSettings = GetComponent<PlayerSettings>();
        playerController = GetComponent<PlayerController>();
        uiManager = FindObjectOfType<UIManager>();
        achievementTracker = FindObjectOfType<AchievementTracker>();

        changeArrowColour(playerStats.trashAmount / playerSettings.maxCapacity);
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

                    if (progress >= 1)
                    {
                        playerStats.totalTrashCollected += playerSettings.trashValue;
                        achievementTracker.newTrashCollectedRecord();
                        playerStats.trashAmount += playerSettings.trashValue;

                        float capacityFilled = checkPlayerCapacity();
                        changeArrowColour(capacityFilled);

                        uiManager.changeTrashIcon(capacityFilled);

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

    private float checkPlayerCapacity()
    {
        float capacityFilled = playerStats.trashAmount / playerSettings.maxCapacity;

        return capacityFilled;
    }

    public void changeArrowColour(float capacityFilled)
    {
        if (capacityFilled < 0.5)
        {
            float colourChange = capacityFilled * 2;
            arrowMaterial.color = Color.Lerp(Color.green, Color.yellow, colourChange);
            arrowMaterial.SetColor("_EmissionColor", Color.Lerp(Color.green, Color.yellow, colourChange));
        }
        else if (capacityFilled >= 0.5)
        {
            arrowMaterial.color = Color.Lerp(Color.yellow, Color.red, capacityFilled);
            arrowMaterial.SetColor("_EmissionColor", Color.Lerp(Color.yellow, Color.red, capacityFilled));
        }
    }
}