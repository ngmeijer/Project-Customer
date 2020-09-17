using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singleton

    public static void DontDestroyChildOnLoad(GameObject child)
    {
        Transform parentTransform = child.transform;

        while (parentTransform.parent != null)
        {
            parentTransform = parentTransform.parent;
        }
        DontDestroyOnLoad(parentTransform.gameObject);
    }

    #endregion

    #region Variables

    public float trashAmount = 0;
    public float money = 0;
    public float supporters = 0;
    public float totalTrashCollected = 0;

    private UIManager uiManager = null;

    #endregion

    private void OnEnable()
    {
        supporters = StatsToSave.totalSupporters;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void calculateSupporters(int supporterDelta)
    {
        supporters += supporterDelta;
        if (supporters < 0)
        {
            supporters = 0;
        }
        uiManager.updateSupporters(uiManager.supportersCounter, supporters);
    }

    public float calculateMoney(int rewardedMoney)
    {
        money += rewardedMoney;
        return money;
    }
}