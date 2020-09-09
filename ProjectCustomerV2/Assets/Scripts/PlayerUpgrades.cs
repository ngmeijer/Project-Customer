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

    public GameObject firstUpgrade = null;
    public GameObject secondUpgrade = null;
    public GameObject thirdUpgrade = null;

    public bool unlockedFirstUpgrade = false;
    public bool unlockedSecondUpgrade = false;
    public bool unlockedThirdUpgrade = false;

    [SerializeField] private int newCapacity = 300;
    [SerializeField] private int newMoveSpeed = 10;
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
                            playerStats.money -= upgradePrice;
                            uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false);
                            break;
                        case 1:
                            //Fishnet
                            unlockedSecondUpgrade = true;
                            secondUpgrade.SetActive(true);
                            playerStats.money -= upgradePrice;
                            playerSettings.pickupTime = newPickupSpeed;
                            uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false);
                            break;
                        case 2:
                            //Trailer = capacity upgrade
                            unlockedThirdUpgrade = true;
                            thirdUpgrade.SetActive(true);
                            playerSettings.maxCapacity = newCapacity;
                            playerStats.money -= upgradePrice;
                            uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false);
                            break;
                    }
                    break;
                case 1:
                    switch (selectedUpgrade)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
                case 2:
                    switch (selectedUpgrade)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
                case 3:
                    switch (selectedUpgrade)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
            }
        }
    }
}
