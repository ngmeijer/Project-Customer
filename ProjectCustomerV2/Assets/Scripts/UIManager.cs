using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerController playerController = null;
    private PlayerStats playerStats = null;
    private PlayerSettings playerSettings = null;
    private SocialMedia socialMedia = null;

    private Animator animator = null;

    [SerializeField] private Transform player = null;
    [SerializeField] private Transform basePosition = null;

    [Header("Counters")]
    public TextMeshProUGUI trashCounter = null;
    public TextMeshProUGUI maxTrashCounter = null;
    public TextMeshProUGUI moneyCounter = null;
    public TextMeshProUGUI supportersCounter = null;
    public TextMeshProUGUI timer = null;

    public GameObject upgradeEquippedText = null;
    [SerializeField] private Image trashIcon;
    [SerializeField] private Sprite[] trashSprites;

    [SerializeField] private GameObject storeButton = null;
    [SerializeField] private GameObject storeUI = null;
    [SerializeField] private GameObject UIInactiveWhileInStore = null;

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
        playerController = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerSettings = FindObjectOfType<PlayerSettings>();
        socialMedia = FindObjectOfType<SocialMedia>();

        animator = GetComponent<Animator>();

        includeMaxValueText(maxTrashCounter, (int)playerSettings.maxCapacity);
        updateSupporters(supportersCounter, playerStats.supporters);
    }

    public void newTweet()
    {
        string tweet = socialMedia.sendOutPositiveTweet();

        tweetText.text = tweet;

        animator.SetTrigger("ShowTweet");
    }

    public void handleStoreOnClick()
    {
        float distance = Vector3.Distance(player.transform.position, basePosition.transform.position);

        if (distance <= 30)
        {
            UIInactiveWhileInStore.SetActive(false);
            playerController.enabled = false;
            storeUI.SetActive(true);
        }
    }

    public void handleStoreOnExit()
    {
        UIInactiveWhileInStore.SetActive(true);
        playerController.enabled = true;
        storeUI.SetActive(false);
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

    public void includeMaxValueText(TextMeshProUGUI maxValueText, float maxValue)
    {
        maxValueText.enabled = true;
        maxValueText.text = "/ " + maxValue.ToString();
    }

    public void updateSupporters(TextMeshProUGUI counter, float counterAmount)
    {
        float totalSupporters = playerStats.supporters;

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
    public void hideProgressbar()
    {
        pickupSlider.value = 0;
        progressBar.SetActive(false);
    }

    public void changeTrashIcon(float capacityFilled)
    {
        capacityFilled *= 100;

        if (capacityFilled < 50)
            trashIcon.sprite = trashSprites[0];

        if (capacityFilled >= 50 && capacityFilled < 99)
            trashIcon.sprite = trashSprites[1];

        if (capacityFilled == 100)
            trashIcon.sprite = trashSprites[2];
    }

    public void handleInterceptorExclamation(bool active)
    {
        //exclamationMark.SetActive(active);
    }
}
