﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject paddleUpgrade = null;
    public GameObject fishnetUpgrade = null;

    public void activateUpgrade(GameObject selectedUpgrade)
    {
        selectedUpgrade.SetActive(true);
    }
}
