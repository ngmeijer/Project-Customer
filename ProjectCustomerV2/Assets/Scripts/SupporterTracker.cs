using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterTracker : MonoBehaviour
{
    private PlayerStats playerStats = null;
    private SupporterTracker supporterTracker = null;
    private UIManager uiManager = null;
    [SerializeField] private float newSupporterInterval = 1f;
    [SerializeField] private int amountOfNewSupporters = 10;

    private float timer = 0f;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        supporterTracker = FindObjectOfType<SupporterTracker>();
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
            calculateSupporters(amountOfNewSupporters);
            uiManager.updateSupporters(uiManager.supportersCounter, amountOfNewSupporters);
            timer = 0;
        }
    }

    public int calculateSupporters(int supportersGained)
    {
        int supporters = playerStats.supporters += supportersGained;

        return supporters;
    }

    public void calculateSupportersOnTrashDep(int trashAmount)
    {
        int supporters = trashAmount;

        playerStats.supporters += supporters;
    }
}
