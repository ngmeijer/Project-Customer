﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject store = null;

    private TrashGenerator trashGenerator = null;
    private PlayerController playerController = null;
    private PlayerStats playerStats = null;

    public TextMeshProUGUI trashCounter = null;

    [SerializeField] private GameObject storeUI = null;
    [SerializeField] private GameObject storeButton = null;

    private void Start()
    {
        trashGenerator = FindObjectOfType<TrashGenerator>();
        playerController = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void handleStoreVisible()
    {
        if (!store.activeInHierarchy)
        {
            store.SetActive(true);

            trashGenerator.enabled = false;
            playerController.enabled = false;

            storeButton.SetActive(false);
        }
        else
        {
            store.SetActive(false);

            trashGenerator.enabled = true;
            playerController.enabled = true;

            storeButton.SetActive(true);
        }
    }

    public void handleStoreOnEnter()
    {
        if (!storeUI.activeInHierarchy)
        {
            storeUI.SetActive(true);

        }
        else
        {
            storeUI.SetActive(false);
        }
    }

    public void updateStats(TextMeshProUGUI counter)
    {
        counter.text = playerStats.trashAmount.ToString();
    }
}
