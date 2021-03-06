﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    #region Variables

    private PlayerController playerController;

    public static int supporterDecrement = 1;

    public float maxCapacity = 200;
    public int speed = 4;

    public int trashValue = 20;

    public float pickupTime = 2f;

    public bool lockMovementWhileTrashing = true;
    public bool canCollectTrash = true;

    #endregion

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        playerController.playerAgent.speed = speed;
    }
}
