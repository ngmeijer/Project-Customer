using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoreSettings))]
public class StoreManager : MonoBehaviour
{
    private PlayerUpgrades playerUpgrades = null;
    private PlayerStats playerStats = null;
    private PlayerSettings playerSettings = null;
    private UIManager uiManager = null;
    private StoreSettings storeSettings = null;
    private AchievementTracker achievementTracker = null;

    [SerializeField] private int currentLevel = 0;

    private void Start()
    {
        playerUpgrades = FindObjectOfType<PlayerUpgrades>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        uiManager = GetComponent<UIManager>();
        storeSettings = GetComponent<StoreSettings>();
        achievementTracker = FindObjectOfType<AchievementTracker>();
    }

    public void buyFirstUpgrade()
    {
        Debug.Log(playerStats.money);
        if (storeSettings.firstUpgradePrice >= playerStats.money)
        {
            playerUpgrades.applyUpgrades(currentLevel, 0, storeSettings.firstUpgradePrice);
        }
    }

    public void buySecondUpgrade()
    {
        playerUpgrades.applyUpgrades(currentLevel, 1, storeSettings.secondUpgradePrice);
    }

    public void buyThirdUpgrade()
    {
        playerUpgrades.applyUpgrades(currentLevel, 2, storeSettings.thirdUpgradePrice);
    }

    public void emptyTrash()
    {
        playerStats.calculateMoney(playerStats.trashAmount);
        uiManager.updateStats(uiManager.moneyCounter, playerStats.money);
        playerStats.trashAmount = 0;
        uiManager.updateStats(uiManager.trashCounter, playerStats.trashAmount);
    }
}
