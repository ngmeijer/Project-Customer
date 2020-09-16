using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterTracker : MonoBehaviour
{
    private PlayerStats playerStats = null;
    private SocialMedia socialMedia = null;
    private UIManager uiManager = null;
    [SerializeField] private float newSupporterInterval = 0.1f;
    [SerializeField] private int amountOfNewSupporters = 10;
    [SerializeField] private float moneyPerSupporter = 0.5f;

    private string tweet;

    private float timer = 0f;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        socialMedia = GetComponent<SocialMedia>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        addNewSupporters();
    }

    private void addNewSupporters()
    {
        timer += Time.deltaTime;

        if (timer >= newSupporterInterval)
        {
            playerStats.supporters += amountOfNewSupporters;
            playerStats.money += (moneyPerSupporter * playerStats.supporters);
            uiManager.updateStats(uiManager.moneyCounter, playerStats.money, false, false);
            uiManager.updateSupporters(uiManager.supportersCounter, playerStats.supporters);
            timer = 0;
        }
    }

    public void calculateSupportersOnTrashDep(int trashAmount)
    {
        int supporters = trashAmount;

        playerStats.supporters += supporters;
    }
}
