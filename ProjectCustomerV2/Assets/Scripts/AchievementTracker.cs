using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTracker : MonoBehaviour
{
    #region Singleton

    public static AchievementTracker Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(this); }
    }

    #endregion

    #region Variables

    private int trashRecord;
    [SerializeField] private int[] trashRecords = new int[3];

    [SerializeField] private int shipsRecord;
    [SerializeField] private int upgradeRecord;
    [SerializeField] private int levelRecord;

    private SocialMedia socialMedia = null;
    private UIManager uiManager = null;

    private bool trashRec1Unlocked;
    private bool trashRec2Unlocked;
    private bool trashRec3Unlocked;
    private bool trashRec4Unlocked;

    #endregion

    private void Start()
    {
        socialMedia = GetComponent<SocialMedia>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void newTrashCollectedRecord(int newTrashRecord)
    {
        trashRecord += newTrashRecord;

        if (!trashRec1Unlocked)
            if (trashRecord >= 25 && trashRecord < trashRecords[1])
            {
                uiManager.newTweet();
                Debug.Log("New record! 25 trash collected");
                trashRec1Unlocked = true;
            }

        if (!trashRec2Unlocked)
            if (trashRecord >= trashRecords[1] && trashRecord < trashRecords[2])
            {
                uiManager.newTweet();
                Debug.Log("New record! 100 trash collected");
                trashRec2Unlocked = true;
            }

        if (!trashRec3Unlocked)
            if (trashRecord >= trashRecords[2] && trashRecord < trashRecords[3])
            {
                uiManager.newTweet();
                Debug.Log("New record! 500 trash collected");
                trashRec3Unlocked = true;
            }

        if (!trashRec4Unlocked)
            if (trashRecord >= trashRecords[3])
            {
                uiManager.newTweet();
                Debug.Log("New record! 1000 trash collected");
                trashRec4Unlocked = true;
            }
    }

    public void newShipsKilledRecord(int newShipsKilledRecord)
    {
        shipsRecord = newShipsKilledRecord;
    }

    public void upgradeShipRecord(int newUpgradeRecord)
    {
        upgradeRecord = newUpgradeRecord;
    }

    public void levelCompleteRecord(int newLevelRecord)
    {
        levelRecord = newLevelRecord;
    }
}
