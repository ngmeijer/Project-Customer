using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashGenerator : MonoBehaviour
{
    public static TrashGenerator SharedInstance;

    [SerializeField] private List<GameObject> pooledObjects;

    [SerializeField] private List<Vector3> spawningPositions;

    private TrashGeneratorSettings trashGeneratorSettings = null;

    private float trashTimer = 0.0f;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        trashGeneratorSettings = GetComponent<TrashGeneratorSettings>();

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < trashGeneratorSettings.amountToPool; i++)
        {
            int randomTrash = randomTrashPrefab();
            GameObject trashInstance = Instantiate(trashGeneratorSettings.trashPrefabs[randomTrash]);
            trashInstance.SetActive(false);
            pooledObjects.Add(trashInstance);
        }
    }

    private void Update()
    {
        trashTimer += Time.deltaTime;

        if (trashTimer > trashGeneratorSettings.trashSpawnRate)
        {
            generateTrash();
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    private void generateTrash()
    {
        Vector3 point;

        if (RandomPoint(transform.position, trashGeneratorSettings.spawnRange, out point))
        {
            spawningPositions.Add(point);

            for (int i = 0; i < spawningPositions.Count; i++)
            {
                float distanceToOtherPoint = Vector3.Distance(point, spawningPositions[i]);

                if (distanceToOtherPoint >= trashGeneratorSettings.minDistanceToOtherTrash)
                {
                    GameObject trashInstance = GetPooledObject();
                    if (trashInstance != null)
                    {
                        trashInstance.transform.position = point;
                        trashInstance.transform.rotation = Quaternion.identity;
                        trashInstance.SetActive(true);
                    }
                }
            }
        }
        trashTimer = 0;
    }

    private int randomTrashPrefab()
    {
        int randomPrefab = Random.Range(0, trashGeneratorSettings.trashPrefabs.Count);

        return randomPrefab;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 50; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
