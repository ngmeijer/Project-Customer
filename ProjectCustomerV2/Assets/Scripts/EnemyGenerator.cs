using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator SharedInstance;

    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private int amountToPool = 20;

    private EnemyGeneratorSettings enemyGeneratorSettings = null;

    private float enemySpawnTimer = 0.0f;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        enemyGeneratorSettings = GetComponent<EnemyGeneratorSettings>();

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            int randomEnemy = chooseRandomEnemy();
            GameObject trashInstance = Instantiate(enemyPrefabs[randomEnemy]);
            trashInstance.SetActive(false);
            pooledObjects.Add(trashInstance);
        }
    }

    private void Update()
    {
        enemySpawnTimer += Time.deltaTime;

        if (enemySpawnTimer > enemyGeneratorSettings.spawnRate)
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
        int randomPrefab = chooseRandomEnemy();

        Vector3 point;
        if (RandomPoint(transform.position, enemyGeneratorSettings.spawnRange, out point))
        {
            GameObject trashInstance = GetPooledObject();
            if (trashInstance != null)
            {
                trashInstance.transform.position = point;
                trashInstance.transform.rotation = Quaternion.identity;
                trashInstance.SetActive(true);
            }
            //Debug.DrawRay(point, Vector3.up, Color.blue, enemyGeneratorSettings.enemy);
        }

        enemySpawnTimer = 0;
    }

    private int chooseRandomEnemy()
    {
        int randomPrefab = Random.Range(0, enemyPrefabs.Count);

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
