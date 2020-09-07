using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorController : MonoBehaviour
{
    private UIManager uiManager = null;
    private PlayerStats playerStats = null;
    private SupporterTracker supporterTracker = null;
    private InterceptorSettings interceptorSettings = null;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        supporterTracker = FindObjectOfType<SupporterTracker>();
        interceptorSettings = GetComponent<InterceptorSettings>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.updateStats(uiManager.interceptorHealth, interceptorSettings.health, true);
            uiManager.handleInterceptorOnEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.handleInterceptorOnExit();
        }
    }

    public void emptyTrash()
    {
        playerStats.calculateMoney((int)playerStats.trashAmount);
        uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false);

        supporterTracker.calculateSupportersOnTrashDep((int)playerStats.trashAmount);
        uiManager.updateSupporters(uiManager.supportersCounter, playerStats.supporters);
        playerStats.trashAmount = 0;
        uiManager.updateStats(uiManager.trashCounter, (int)playerStats.trashAmount, false);
    }

    public void repairInterceptor()
    {
        interceptorSettings.health = interceptorSettings.maxHealth;
        uiManager.updateStats(uiManager.interceptorHealth, interceptorSettings.health, true);
    }
}
