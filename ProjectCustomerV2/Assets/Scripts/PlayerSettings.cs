using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    #region Variables

    private PlayerController playerController;

    public float maxCapacity = 200;
    public int speed = 4;

    public int smallTrash = 20;
    public int bigTrash = 50;

    public float pickupTime = 2f;

    #endregion

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        playerController.playerAgent.speed = speed;
    }
}
