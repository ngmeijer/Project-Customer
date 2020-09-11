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
    public int money = 0;
    public int supporters = 0;
    public int totalTrashCollected = 0;

    #endregion

    public int calculateMoney(int rewardedMoney)
    {
        money += (int)rewardedMoney;

        return money;
    }
}
