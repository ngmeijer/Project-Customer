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

    public int trashAmount = 0;
    public int money = 0;
    public int supporters = 0;

    #endregion

    public int calculateMoney(int rewardedMoney)
    {
        money += rewardedMoney;

        return money;
    }

    public int calculateSupporters(int supportersGained)
    {
        supporters += supportersGained;

        return supporters;
    }

    //public void updateSupporters(TextMeshProUGUI counter, int counterAmount)
    //{
    //    int totalSupporters = playerStats.supporters;

    //    playerStats.supporters += counterAmount;
    //    counter.text = totalSupporters.ToString();
    //}
}
