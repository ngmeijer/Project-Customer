using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(StoreSettings))]
public class StoreManager : MonoBehaviour
{
    private PlayerUpgrades playerUpgrades = null;
    private PlayerStats playerStats = null;
    private UIManager uiManager = null;
    private StoreSettings storeSettings = null;

    [SerializeField] private int currentLevel = 0;

    [SerializeField] private TextMeshProUGUI[] priceText = new TextMeshProUGUI[3];

    private void Start()
    {
        playerUpgrades = FindObjectOfType<PlayerUpgrades>();
        playerStats = FindObjectOfType<PlayerStats>();
        uiManager = GetComponent<UIManager>();
        storeSettings = GetComponent<StoreSettings>();

        for(int i = 0; i < 3; i++)
        {
            priceText[i].text = storeSettings.upgradePriceList[i].ToString();
        }
    }

    public void buyFirstUpgrade()
    {
        if (storeSettings.upgradePriceList[0] <= playerStats.money)
        {
            playerUpgrades.applyUpgrades(currentLevel, 0, storeSettings.upgradePriceList[0]);
        }
    }

    public void buySecondUpgrade()
    {
        if (storeSettings.upgradePriceList[1] <= playerStats.money)
        {
            playerUpgrades.applyUpgrades(currentLevel, 1, storeSettings.upgradePriceList[1]);
        }
    }

    public void buyThirdUpgrade()
    {
        if (storeSettings.upgradePriceList[2] <= playerStats.money)
        {
            playerUpgrades.applyUpgrades(currentLevel, 2, storeSettings.upgradePriceList[2]);
        }
    }

    public void emptyTrash()
    {
        playerStats.calculateMoney(playerStats.trashAmount);
        uiManager.updateStats(uiManager.moneyCounter, playerStats.money);
        playerStats.trashAmount = 0;
        uiManager.updateStats(uiManager.trashCounter, playerStats.trashAmount);
    }
}
