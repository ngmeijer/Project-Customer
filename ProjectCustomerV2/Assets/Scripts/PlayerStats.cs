using Packages.Rider.Editor.Util;
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

    #endregion

    private void OnEnable()
    {
        supporters = StatsToSave.totalSupporters;
    }

    private void Update()
    {
        Debug.Log(StatsToSave.totalSupporters);
    }


    public float calculateMoney(int rewardedMoney)
    {
        money += rewardedMoney;
        return money;
    }
}
