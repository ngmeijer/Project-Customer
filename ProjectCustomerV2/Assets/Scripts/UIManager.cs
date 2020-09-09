using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private TrashGenerator trashGenerator = null;
    private PlayerController playerController = null;
    private PlayerStats playerStats = null;

    private Animator animator = null;

    [Header("Counters")]
    public TextMeshProUGUI trashCounter = null;
    public TextMeshProUGUI moneyCounter = null;
    public TextMeshProUGUI supportersCounter = null;
    public TextMeshProUGUI timer = null;

    [SerializeField] private GameObject interceptorUI = null;
    public TextMeshProUGUI interceptorHealth = null;

    public GameObject upgradeEquippedText = null;

    [SerializeField] private GameObject exclamationMark = null;

    [SerializeField] private GameObject storeUI = null;
    [SerializeField] private GameObject UIInactiveWhileInStore = null;

    [SerializeField] private GameObject upgradesPanel = null;

    [Header("Mobile UI")]
    [SerializeField] private TextMeshProUGUI tweetText = null;
    [SerializeField] private GameObject shipFullText = null;
    [SerializeField] private GameObject progressBar = null;
    [SerializeField] private Slider slider = null;

    private void Start()
    {
        trashGenerator = FindObjectOfType<TrashGenerator>();
        playerController = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();

        animator = GetComponent<Animator>();
    }

    public void handleStoreOnEnter()
    {
        UIInactiveWhileInStore.SetActive(false);
        playerController.enabled = false;
        storeUI.SetActive(true);
    }

    public IEnumerator unlockedUpgradeWarning()
    {
        upgradeEquippedText.SetActive(true);

        yield return new WaitForSeconds(2f);

        upgradeEquippedText.SetActive(false);

        yield break;
    }

    public void handleStoreOnExit()
    {
        UIInactiveWhileInStore.SetActive(true);
        playerController.enabled = true;
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

    public void handleShipFullNotif(bool active)
    {
        shipFullText.SetActive(active);
    }

    public void updateStats(TextMeshProUGUI counter, int counterAmount, bool includePercentage)
    {
        if (!includePercentage)
            counter.text = counterAmount.ToString();
        else
            counter.text = counterAmount.ToString() + "%";
    }

    public void updateSupporters(TextMeshProUGUI counter, int counterAmount)
    {
        int totalSupporters = playerStats.supporters;

        playerStats.supporters = counterAmount;
        counter.text = totalSupporters.ToString();
    }

    public void showUpgradesPanel()
    {
        animator.SetTrigger("ShowUpgrades");
    }

    public void hideUpgradesPanel()
    {
        animator.SetTrigger("HideUpgrades");
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

    public void showProgressBar(float progress)
    {
        progressBar.SetActive(true);
        slider.value = progress;
    }

    public void hideProgressbar()
    {
        slider.value = 0;
        progressBar.SetActive(false);
    }

    public void pauseGame()
    {
        animator.SetTrigger("Pause");
        Time.timeScale = 0;
    }

    public void handleInterceptorExclamation(bool active)
    {
        exclamationMark.SetActive(active);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        animator.SetTrigger("Resume");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void donateButton()
    {
        Application.OpenURL("https://theoceancleanup.com/donate/");
    }
}
