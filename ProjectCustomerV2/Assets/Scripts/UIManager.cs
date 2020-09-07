using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private TrashGenerator trashGenerator = null;
    private PlayerController playerController = null;
    private PlayerStats playerStats = null;

    private Animator animator = null;

    public TextMeshProUGUI trashCounter = null;
    public TextMeshProUGUI moneyCounter = null;
    public TextMeshProUGUI supportersCounter = null;
    public TextMeshProUGUI timer = null;

    [SerializeField] private GameObject interceptorUI = null;
    public TextMeshProUGUI interceptorHealth = null;

    [SerializeField] private GameObject store = null;
    [SerializeField] private GameObject storeUI = null;
    [SerializeField] private GameObject storeButton = null;

    [SerializeField] private TextMeshProUGUI tweetText = null;

    private void Start()
    {
        trashGenerator = FindObjectOfType<TrashGenerator>();
        playerController = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();

        animator = GetComponent<Animator>();
    }

    public void handleStoreOnEnter()
    {
        storeUI.SetActive(true);
    }

    public void handleStoreOnExit()
    {
        storeUI.SetActive(false);
    }

    public void handleInterceptorOnEnter()
    {
        interceptorUI.SetActive(true);
    }

    public void handleInterceptorOnExit()
    {
        interceptorUI.SetActive(false);
    }

    public void updateStats(TextMeshProUGUI counter, int counterAmount, bool includePercentage)
    {
        if (!includePercentage)
        {
            counter.text = counterAmount.ToString();
        }
        else
        {
            counter.text = counterAmount.ToString() + "%";
        }
    }

    public void updateSupporters(TextMeshProUGUI counter, int counterAmount)
    {
        int totalSupporters = playerStats.supporters;

        playerStats.supporters = counterAmount;
        counter.text = totalSupporters.ToString();
    }

    public void showTimer(int timeLeft)
    {
        timer.text = timeLeft.ToString();
    }

    public void showTweet(string text)
    {
        animator.SetTrigger("ShowTweet");

        tweetText.text = text;
    }

    public void pauseGame()
    {
        animator.SetTrigger("Pause");
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        animator.SetTrigger("Resume");
    }
}
