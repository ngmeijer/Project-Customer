using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterTracker : MonoBehaviour
{
    private PlayerStats playerStats = null;
    private SocialMedia socialMedia = null;
    private UIManager uiManager = null;
    [SerializeField] private float newSupporterInterval = 1f;
    [SerializeField] private int amountOfNewSupporters = 10;

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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            tweet = socialMedia.sendOutPositiveTweet();

            uiManager.showTweet(tweet);
        }
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

        if(supporters >= socialMedia.newPostTreshhold)
        {
            tweet = socialMedia.sendOutPositiveTweet();

            uiManager.showTweet(tweet);
        }

        return supporters;
    }

    public void calculateSupportersOnTrashDep(int trashAmount)
    {
        int supporters = trashAmount;

        playerStats.supporters += supporters;
    }
}
