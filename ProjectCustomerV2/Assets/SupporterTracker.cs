using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterTracker : MonoBehaviour
{
    private PlayerStats playerStats = null;
    private UIManager uiManager = null;
    [SerializeField] private float newSupporterInterval = 1f;
    [SerializeField] private int amountOfNewSupporters = 10;

    private float timer = 0f;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        addNewSupporters();
    }

    private void addNewSupporters()
    {
        Debug.Log(timer);
        timer += Time.deltaTime;

        if (timer >= newSupporterInterval)
        {
            playerStats.calculateSupporters(amountOfNewSupporters);
            uiManager.updateSupporters(uiManager.supportersCounter, amountOfNewSupporters);
            timer = 0;
        }
    }
}
