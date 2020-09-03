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

    #endregion

    public void newTrashCollectedRecord(int newTrashRecord)
    {
        trashRecord += newTrashRecord;

        if (trashRecord >= 25)
        {
            Debug.Log("New record! 25 trash collected");
        }
        if (trashRecord >= trashRecords[1])
        { Debug.Log("New record! 100 trash collected"); }
        if (trashRecord >= trashRecords[2])
        { Debug.Log("New record! 500 trash collected"); }
        if (trashRecord >= trashRecords[3])
        { Debug.Log("New record! 1000 trash collected"); }
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
