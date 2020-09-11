using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(StoreSettings))]
public class StoreManager : MonoBehaviour
{
    private PlayerUpgrades playerUpgrades = null;
    private PlayerStats playerStats = null;
    private SupporterTracker supporterTracker = null;
    private UIManager uiManager = null;
    private StoreSettings storeSettings = null;

    [SerializeField] private int currentLevel = 0;

    [SerializeField] private TextMeshProUGUI[] priceText = new TextMeshProUGUI[3];

    private void Start()
    {
        playerUpgrades = FindObjectOfType<PlayerUpgrades>();
        playerStats = FindObjectOfType<PlayerStats>();
        supporterTracker = FindObjectOfType<SupporterTracker>();
        uiManager = GetComponent<UIManager>();
        storeSettings = GetComponent<StoreSettings>();

        for (int i = 0; i < 3; i++)
        {
            priceText[i].text = storeSettings.upgradePriceList[i].ToString();
        }
    }

    public void buyFirstUpgrade()
    {
        if (!playerUpgrades.unlockedFirstUpgrade)
        {
            if (storeSettings.upgradePriceList[0] <= playerStats.money)
            {
                playerUpgrades.applyUpgrades(currentLevel, 0, storeSettings.upgradePriceList[0]);
            }
        }
        else
        {
            Debug.Log("already bought upgrade");
            StartCoroutine(uiManager.unlockedUpgradeWarning());
        }
    }

    public void buySecondUpgrade()
    {
        if (!playerUpgrades.unlockedSecondUpgrade)
        {
            if (storeSettings.upgradePriceList[1] <= playerStats.money)
            {
                playerUpgrades.applyUpgrades(currentLevel, 1, storeSettings.upgradePriceList[1]);
            }
        }
        else
        {
            Debug.Log("already bought upgrade");
            StartCoroutine(uiManager.unlockedUpgradeWarning());
        }
    }

    public void buyThirdUpgrade()
    {
        if (!playerUpgrades.unlockedThirdUpgrade)
        {
            if (storeSettings.upgradePriceList[2] <= playerStats.money)
            {
                playerUpgrades.applyUpgrades(currentLevel, 2, storeSettings.upgradePriceList[2]);
            }
        }
        else
        {
            Debug.Log("already bought upgrade");
            StartCoroutine(uiManager.unlockedUpgradeWarning());
        }
    }

    public void emptyTrash()
    {
        playerStats.calculateMoney((int)playerStats.trashAmount);
        uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false, false);

        //supporterTracker.calculateSupportersOnTrashDep((int)playerStats.trashAmount);
        //uiManager.updateSupporters(uiManager.supportersCounter, playerStats.supporters);

        playerStats.totalTrashCollected += (int)playerStats.trashAmount;
        playerStats.trashAmount = 0;

        uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false, false);
    }
}
