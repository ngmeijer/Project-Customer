using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    private PlayerUpgrades playerInventory = null;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerUpgrades>();
    }

    public void buyPaddles()
    {
        playerInventory.activateUpgrade(playerInventory.paddleUpgrade);
    }

    public void buyFishnet()
    {
        playerInventory.activateUpgrade(playerInventory.fishnetUpgrade);
    }
}
