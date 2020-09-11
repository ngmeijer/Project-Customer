using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private TrashGenerator trashGenerator = null;
    private PlayerController playerController = null;
    private PlayerStats playerStats = null;
    private PlayerSettings playerSettings = null;
    private SocialMedia socialMedia = null;

    private Animator animator = null;

    [Header("Counters")]
    public TextMeshProUGUI trashCounter = null;
    public TextMeshProUGUI maxTrashCounter = null;
    public TextMeshProUGUI moneyCounter = null;
    public TextMeshProUGUI supportersCounter = null;
    public TextMeshProUGUI timer = null;

    [SerializeField] private GameObject interceptorUI = null;
    public TextMeshProUGUI interceptorHealth = null;

    public GameObject upgradeEquippedText = null;

    [SerializeField] private GameObject exclamationMark = null;

    [SerializeField] private GameObject storeButton = null;
    [SerializeField] private GameObject storeUI = null;
    [SerializeField] private GameObject UIInactiveWhileInStore = null;

    [SerializeField] private GameObject upgradesPanel = null;

    [Header("Mobile UI")]
    [SerializeField] private TextMeshProUGUI tweetText = null;
    [SerializeField] private GameObject shipFullText = null;
    [SerializeField] private GameObject progressBar = null;
    [SerializeField] private Slider pickupSlider = null;

    [SerializeField] private GameObject interceptor1Canvas = null;
    [SerializeField] private GameObject interceptor2Canvas = null;
    [SerializeField] private GameObject interceptor3Canvas = null;

    public Slider trashSlider1 = null;
    public Slider trashSlider2 = null;
    public Slider trashSlider3 = null;

    public Slider healthSlider1 = null;
    public Slider healthSlider2 = null;
    public Slider healthSlider3 = null;

    private void Start()
    {
        trashGenerator = FindObjectOfType<TrashGenerator>();
        playerController = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        socialMedia = FindObjectOfType<SocialMedia>();

        animator = GetComponent<Animator>();

        includeMaxValueText(maxTrashCounter, (int)playerSettings.maxCapacity);
    }

    public void newTweet()
    {
        string tweet = socialMedia.sendOutPositiveTweet();

        tweetText.text = tweet;

        animator.SetTrigger("ShowTweet");
    }

    public void activateStoreButton()
    {
        storeButton.SetActive(true);
    }

    public void handleStoreOnClick()
    {
        UIInactiveWhileInStore.SetActive(false);
        playerController.enabled = false;
        storeUI.SetActive(true);
        storeButton.SetActive(false);
    }

    public void handleStoreOnExit()
    {
        UIInactiveWhileInStore.SetActive(true);
        playerController.enabled = true;
        storeUI.SetActive(false);
        storeButton.SetActive(true);
    }

    public IEnumerator unlockedUpgradeWarning()
    {
        upgradeEquippedText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        upgradeEquippedText.SetActive(false);

        yield break;
    }

    public void handleInterceptorOnExit(int selectedInterceptor)
    {
        switch (selectedInterceptor)
        {
            case 0:
                interceptor1Canvas.SetActive(false);
                break;
            case 1:
                interceptor2Canvas.SetActive(false);
                break;
            case 2:
                interceptor3Canvas.SetActive(false);
                break;
        }
    }

    public void handleShipFullNotif(bool active)
    {
        shipFullText.SetActive(active);
    }

    public void updateStats(TextMeshProUGUI counter, float counterAmount, bool includePercentage, bool includeMaxValue)
    {
        if (!includePercentage)
            counter.text = counterAmount.ToString();
        else
            counter.text = counterAmount.ToString() + "%";

        if (includeMaxValue)
        {
            includeMaxValueText(maxTrashCounter, (int)playerSettings.maxCapacity);
        }
    }

    public void includeMaxValueText(TextMeshProUGUI maxValueText, int maxValue)
    {
        maxValueText.enabled = true;
        maxValueText.text = "/ " + maxValue.ToString();
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
        pickupSlider.value = progress;
    }

    public void showInterceptorBars(int selectedInterceptor, float healthValue, float trashValue)
    {
        switch (selectedInterceptor)
        {
            case 0:
                interceptor1Canvas.SetActive(true);
                healthSlider1.value = healthValue;
                trashSlider1.value = trashValue;
                break;
            case 1:
                interceptor2Canvas.SetActive(true);
                healthSlider2.value = healthValue;
                trashSlider2.value = trashValue;
                break;
            case 2:
                interceptor3Canvas.SetActive(true);
                healthSlider3.value = healthValue;
                trashSlider3.value = trashValue;
                break;
        }
    }

    public void hideProgressbar()
    {
        pickupSlider.value = 0;
        progressBar.SetActive(false);
    }

    public void pauseGameWrapper()
    {
        StartCoroutine(pauseGame());
    }

    public IEnumerator pauseGame()
    {
        animator.SetTrigger("Pause");

        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.1f;

        yield break;
    }

    public void resumeGameWrapper()
    {
        StartCoroutine(resumeGame());
    }

    public IEnumerator resumeGame()
    {
        animator.SetTrigger("Resume");
        Time.timeScale = 1;

        yield break;
    }

    public void handleInterceptorExclamation(bool active)
    {
        exclamationMark.SetActive(active);
    }

    public void quitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void donateButton()
    {
        Application.OpenURL("https://theoceancleanup.com/donate/");
    }
}
