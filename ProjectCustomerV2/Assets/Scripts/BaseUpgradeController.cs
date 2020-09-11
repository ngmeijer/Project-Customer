using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseUpgradeController : MonoBehaviour
{
    private UIManager uiManager = null;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.activateStoreButton();
            uiManager.handleShipFullNotif(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.handleStoreOnExit();
        }
    }
}
