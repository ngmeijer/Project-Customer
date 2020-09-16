using System;
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
    [SerializeField] private Material upgradedMaterial = null;

    [SerializeField] private GameObject objectToChangeMat;

    private int lightLevel = 0;
    [SerializeField] private int selectedInterceptor;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        supporterTracker = FindObjectOfType<SupporterTracker>();
        interceptorSettings = GetComponent<InterceptorSettings>();

        trackCapacity();
        //Base colour
        panelMaterial.SetColor("Color_B5409964", interceptorSettings.lightColours[0]);
        //Emission colour
        panelMaterial.SetColor("Color_AFE71EF4", interceptorSettings.lightColours[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float healthInPercentage = interceptorSettings.health / interceptorSettings.maxHealth;
            uiManager.showInterceptorBars(selectedInterceptor, interceptorSettings.health, healthInPercentage);

            float trashInPercentage = interceptorSettings.currentTrashAmount / interceptorSettings.maxTrashAmount;
            uiManager.showInterceptorBars(selectedInterceptor, interceptorSettings.currentTrashAmount, trashInPercentage);
        }

        if (other.gameObject.CompareTag("Trash"))
        {
            if (interceptorSettings.currentTrashAmount < interceptorSettings.maxTrashAmount)
            {
                interceptorSettings.currentTrashAmount += playerSettings.trashValue;
                trackCapacity();
                other.gameObject.SetActive(false);
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
            uiManager.handleInterceptorOnExit(selectedInterceptor);
            uiManager.handleInterceptorExclamation(false);
        }
    }

    public void takeDamage(int damage)
    {
        if (interceptorSettings.health > 0)
            interceptorSettings.health -= damage;
        else
        {
            interceptorSettings.health = 0;
            
        }
    }

    public void applyUpgradeMaterial()
    {
        Renderer renderer = objectToChangeMat.GetComponent<MeshRenderer>();
        renderer.material = upgradedMaterial;
    }

    private void trackCapacity()
    {
        float percentFilled = interceptorSettings.currentTrashAmount / interceptorSettings.maxTrashAmount;

        percentFilled *= 100;

        if (percentFilled <= 25)
        {
            lightLevel = 0;
        }
        else if (percentFilled > 25 && percentFilled <= 50)
        {
            lightLevel = 1;
        }
        else if (percentFilled > 50 && percentFilled <= 75)
        {
            lightLevel = 2;
        }
        else if (percentFilled > 75 && percentFilled <= 100)
        {
            lightLevel = 3;
        }

        if (percentFilled > 90)
        {
            uiManager.handleInterceptorExclamation(true);
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
        if ((interceptorSettings.currentTrashAmount > 0) && (playerStats.trashAmount < playerSettings.maxCapacity))
        {
            float trashTaken = playerStats.trashAmount + interceptorSettings.currentTrashAmount;

            if (playerStats.trashAmount + trashTaken <= playerSettings.maxCapacity)
            {
                playerStats.trashAmount += trashTaken;
                playerStats.totalTrashCollected += (int)trashTaken;
            }
            else playerStats.trashAmount = playerSettings.maxCapacity;

            uiManager.updateStats(uiManager.trashCounter, playerStats.trashAmount, false, true);

            interceptorSettings.currentTrashAmount -= trashTaken;
            if (interceptorSettings.currentTrashAmount < 0)
                interceptorSettings.currentTrashAmount = 0;

            uiManager.showInterceptorBars(selectedInterceptor, interceptorSettings.health, interceptorSettings.currentTrashAmount);
            trackCapacity();
        }
    }

    public void repairInterceptor()
    {
        interceptorSettings.health = interceptorSettings.maxHealth;
        uiManager.showInterceptorBars(selectedInterceptor, interceptorSettings.health, interceptorSettings.currentTrashAmount);
        Debug.Log("trash amount: " + interceptorSettings.currentTrashAmount);
        Debug.Log("health amount: " + interceptorSettings.health);
    }
}
