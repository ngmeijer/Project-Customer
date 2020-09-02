using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    private PlayerInventory playerInventory = null;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
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
