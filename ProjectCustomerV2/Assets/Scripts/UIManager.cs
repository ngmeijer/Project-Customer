using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject store = null;

    private TrashGenerator trashGenerator = null;
    private PlayerController playerController = null;

    private void Start()
    {
        trashGenerator = FindObjectOfType<TrashGenerator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void handleStoreVisible()
    {
        if (!store.activeInHierarchy)
        {
            store.SetActive(true);

            trashGenerator.enabled = false;
            playerController.enabled = false;
        }
        else
        {
            store.SetActive(false);

            trashGenerator.enabled = true;
            playerController.enabled = true;
        }
    }
}
