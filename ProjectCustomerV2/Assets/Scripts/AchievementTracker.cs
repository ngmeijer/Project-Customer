using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private PlayerStats playerStats = null;

    private int trashRecord;
    [SerializeField] private float[] trashRecords = new float[3];

    private SocialMedia socialMedia = null;
    private UIManager uiManager = null;

    private bool trashRec1Unlocked;
    private bool trashRec2Unlocked;
    private bool trashRec3Unlocked;
    private bool trashRec4Unlocked;

    [SerializeField] private Slider trash1Progress = null;
    [SerializeField] private Slider trash2Progress = null;
    [SerializeField] private Slider trash3Progress = null;
    [SerializeField] private Slider trash4Progress = null;

    #endregion

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        socialMedia = GetComponent<SocialMedia>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void newTrashCollectedRecord()
    {
        if (trash1Progress.value < 1)
            trash1Progress.value = playerStats.totalTrashCollected / trashRecords[0];

        if (trash2Progress.value < 1)
            trash2Progress.value = playerStats.totalTrashCollected / trashRecords[1];

        if (trash3Progress.value < 1)
            trash3Progress.value = playerStats.totalTrashCollected / trashRecords[2];

        if (trash4Progress.value < 1)
            trash4Progress.value = playerStats.totalTrashCollected / trashRecords[3];

        if (!trashRec1Unlocked)
            if (playerStats.totalTrashCollected >= 25 && trashRecord < trashRecords[1])
            {
                uiManager.newTweet();
                
                Debug.Log("New record! 25 trash collected");
                trashRec1Unlocked = true;
            }

        if (!trashRec2Unlocked)
            if (playerStats.totalTrashCollected >= trashRecords[1] && trashRecord < trashRecords[2])
            {
                uiManager.newTweet();
                Debug.Log("New record! 100 trash collected");
                trashRec2Unlocked = true;
            }

        if (!trashRec3Unlocked)
            if (playerStats.totalTrashCollected >= trashRecords[2] && trashRecord < trashRecords[3])
            {
                uiManager.newTweet();
                Debug.Log("New record! 500 trash collected");
                trashRec3Unlocked = true;
            }

        if (!trashRec4Unlocked)
            if (playerStats.totalTrashCollected >= trashRecords[3])
            {
                uiManager.newTweet();
                Debug.Log("New record! 1000 trash collected");
                trashRec4Unlocked = true;
            }
    }
}
