using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> trashPrefabs = new List<GameObject>();

    private TrashGeneratorSettings trashGeneratorSettings = null;

    private float trashTimer = 0.0f;

    private void Start()
    {
        trashGeneratorSettings = GetComponent<TrashGeneratorSettings>();
    }

    private void Update()
    {
        trashTimer += Time.deltaTime;

        if (trashTimer > trashGeneratorSettings.trashSpawnRate)
        {
            generateTrash();
        }
    }

    private void generateTrash()
    {
        //int randomPrefab = randomTrashPrefab();

        Vector3 point;
        if (RandomPoint(transform.position, trashGeneratorSettings.spawnRange, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, trashGeneratorSettings.trashLifeTime);
        }

        trashTimer = 0;
    }

    private int randomTrashPrefab()
    {
        int randomPrefab = Random.Range(0, trashPrefabs.Count);

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
