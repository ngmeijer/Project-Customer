using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerSettings playerSettings = null;
    private PlayerController playerController = null;
    private PlayerStats playerStats = null;
    private UIManager uiManager = null;
    private InterceptorController[] interceptorController = null;

    public GameObject firstUpgrade = null;
    public GameObject secondUpgrade = null;
    public GameObject thirdUpgrade = null;

    public bool unlockedFirstUpgrade = false;
    public bool unlockedSecondUpgrade = false;
    public bool unlockedThirdUpgrade = false;

    [SerializeField] private int newCapacity = 400;
    [SerializeField] private int newMoveSpeed = 25;
    [SerializeField] private float newPickupSpeed = 0.5f;

    private void Start()
    {
        playerSettings = GetComponent<PlayerSettings>();
        playerController = GetComponent<PlayerController>();
        playerStats = GetComponent<PlayerStats>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void applyUpgrades(int currentLevel, int selectedUpgrade, int upgradePrice)
    {
        if (upgradePrice > playerStats.money)
        { return; }
        else if (upgradePrice <= playerStats.money)
        {
            playerStats.money -= upgradePrice;
            uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false, false);

            switch (currentLevel)
            {
                case 0:
                    switch (selectedUpgrade)
                    {
                        case 0:
                            //Engine = speed upgrade
                            unlockedFirstUpgrade = true;
                            firstUpgrade.SetActive(true);
                            playerController.playerAgent.speed = newMoveSpeed;

                            break;
                        case 1:
                            //Fishnet = pickup speed upgradeD
                            unlockedSecondUpgrade = true;
                            secondUpgrade.SetActive(true);
                            playerSettings.pickupTime = newPickupSpeed;
                            break;
                        case 2:
                            //Trailer = capacity upgrade
                            unlockedThirdUpgrade = true;
                            thirdUpgrade.SetActive(true);
                            playerSettings.maxCapacity = newCapacity;
                            break;
                    }
                    break;
                case 1:
                    switch (selectedUpgrade)
                    {
                        case 0:
                            //Engine = speed upgrade
                            unlockedFirstUpgrade = true;
                            firstUpgrade.SetActive(true);
                            playerController.playerAgent.speed = newMoveSpeed;
                            break;
                        case 1:
                            //Shiny = reliability upgrade
                            unlockedSecondUpgrade = true;
                            interceptorController = FindObjectsOfType<InterceptorController>();
                            for (int i = 0; i < interceptorController.Length; i++)
                                interceptorController[i].applyUpgradeMaterial();
                            break;
                        case 2:
                            //Box = Capacity upgrade
                            unlockedThirdUpgrade = true;
                            thirdUpgrade.SetActive(true);
                            playerSettings.maxCapacity = newCapacity;
                            uiManager.includeMaxValueText(uiManager.maxTrashCounter, playerSettings.maxCapacity);
                            break;
                    }
                    break;
            }
        }
    }
}
