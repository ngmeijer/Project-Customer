using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorController : MonoBehaviour
{
    private UIManager uiManager = null;
    private PlayerStats playerStats = null;
    private PlayerSettings playerSettings = null;
    private SupporterTracker supporterTracker = null;
    private InterceptorSettings interceptorSettings = null;

    [SerializeField] private Material panelMaterial = null;

    private int lightLevel = 0;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        supporterTracker = FindObjectOfType<SupporterTracker>();
        interceptorSettings = GetComponent<InterceptorSettings>();

        //Base colour
        panelMaterial.SetColor("Color_B5409964", interceptorSettings.lightColours[0]);
        //Emission colour
        panelMaterial.SetColor("Color_AFE71EF4", interceptorSettings.lightColours[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.updateStats(uiManager.interceptorHealth, interceptorSettings.health, true);
            uiManager.handleInterceptorOnEnter();

            if(interceptorSettings.currentTrashAmount >= interceptorSettings.maxTrashAmount)
            {
                uiManager.handleInterceptorExclamation(true);
            }
        }

        if (other.gameObject.CompareTag("SmallTrash") || other.gameObject.CompareTag("BigTrash"))
        {
            TrashController instance = other.gameObject.GetComponent<TrashController>();
            StartCoroutine(instance.handleDeactivation(0f));

            if (interceptorSettings.currentTrashAmount < interceptorSettings.maxTrashAmount)
            {
                if (other.gameObject.CompareTag("SmallTrash"))
                {
                    interceptorSettings.currentTrashAmount += playerSettings.smallTrash;
                    trackCapacity(playerSettings.smallTrash);
                }

                if (other.gameObject.CompareTag("BigTrash"))
                {
                    interceptorSettings.currentTrashAmount += playerSettings.bigTrash;
                    trackCapacity(playerSettings.bigTrash);
                }
            }
            else
            {
                interceptorSettings.currentTrashAmount = interceptorSettings.maxTrashAmount;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.handleInterceptorOnExit();
            uiManager.handleInterceptorExclamation(false);
        }
    }

    private void trackCapacity(int incremention)
    {
        interceptorSettings.currentTrashAmount += incremention;

        float percentFilled = interceptorSettings.currentTrashAmount / interceptorSettings.maxTrashAmount;

        percentFilled *= 100;

        Debug.Log("percent filled " + percentFilled);

        if (percentFilled <= 25)
        {
            lightLevel = 0;
        }
        else if (percentFilled > 25 && percentFilled <= 50)
        {
            lightLevel++;
        }
        else if (percentFilled > 50 && percentFilled <= 75)
        {
            lightLevel++;
        }
        else if (percentFilled > 75 && percentFilled <= 100)
        {
            lightLevel++;
        }

        switch (lightLevel)
        {
            case 0:
                panelMaterial.SetColor("Color_B5409964", interceptorSettings.lightColours[0]);
                panelMaterial.SetColor("Color_AFE71EF4", interceptorSettings.lightColours[0]);
                break;
            case 1:
                panelMaterial.SetColor("Color_B5409964", interceptorSettings.lightColours[1]);
                panelMaterial.SetColor("Color_AFE71EF4", interceptorSettings.lightColours[1]);
                break;
            case 2:
                panelMaterial.SetColor("Color_B5409964", interceptorSettings.lightColours[2]);
                panelMaterial.SetColor("Color_AFE71EF4", interceptorSettings.lightColours[2]);
                break;
            case 3:
                panelMaterial.SetColor("Color_B5409964", interceptorSettings.lightColours[3]);
                panelMaterial.SetColor("Color_AFE71EF4", interceptorSettings.lightColours[3]);
                break;
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
