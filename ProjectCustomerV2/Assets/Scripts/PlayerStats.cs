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
    public int followers = 0;

    public void calculateMoney(int rewardedMoney)
    {
        money += rewardedMoney;
    }

    #endregion
}
