using System.Collections.Generic;
using UnityEngine;

public class TrashGeneratorSettings : MonoBehaviour
{
    #region Variables

    public float trashSpawnRate = 1.0f;

    public float spawnRange = 10.0f;

    public float trashLifeTime = 10f;

    public float minDistanceToOtherTrash = 4f;

    public int amountToPool = 10;

    public List<GameObject> trashPrefabs = new List<GameObject>();

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}