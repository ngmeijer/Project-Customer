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

    [SerializeField] private int newCapacity = 300;
    [SerializeField] private int newMoveSpeed = 10;

    private void Start()
    {
        playerSettings = GetComponent<PlayerSettings>();
        playerController = GetComponent<PlayerController>();
        playerStats = GetComponent<PlayerStats>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void applyUpgrades(int currentLevel, int selectedUpgrade, int upgradePrice)
    {
        Debug.Log("upgrade price = " + upgradePrice + "current money = " + playerStats.money);
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
                            Debug.Log("activated first upgrade");
                            //Paddles = speed upgrade
                            firstUpgrade.SetActive(true);
                            playerController.playerAgent.speed = newMoveSpeed;
                            playerStats.money -= upgradePrice;
                            uiManager.updateStats(uiManager.moneyCounter, playerStats.money);
                            break;
                        case 1:
                            //Fishnet
                            secondUpgrade.SetActive(true);
                            playerStats.money -= upgradePrice;
                            uiManager.updateStats(uiManager.moneyCounter, playerStats.money);
                            break;
                        case 2:
                            //Trailer = capacity upgrade
                            thirdUpgrade.SetActive(true);
                            playerSettings.maxCapacity = newCapacity;
                            playerStats.money -= upgradePrice;
                            uiManager.updateStats(uiManager.moneyCounter, playerStats.money);
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
