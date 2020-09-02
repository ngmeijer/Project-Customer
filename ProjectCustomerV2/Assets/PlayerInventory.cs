using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerStats playerStats = null;
    private UIManager uiManager = null;

    private int smallTrash = 20;
    private int bigTrash = 50;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SmallTrash"))
        {
            playerStats.trashAmount += smallTrash;
            uiManager.updateStats(uiManager.trashCounter);
        }

        if (other.gameObject.CompareTag("BigTrash"))
        {
            playerStats.trashAmount += bigTrash;
            uiManager.updateStats(uiManager.trashCounter);
        }
    }
}
