using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySettings), (typeof(NavMeshAgent)))]
public class EnemyController : MonoBehaviour
{
    #region Variables

    private EnemySettings enemySettings = null;
    private NavMeshAgent enemyAgent = null;
    private Transform player = null;

    private Vector3 finalPosition;

    private float timeBeforeFindNewDirection = 0;

    #endregion

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemySettings = GetComponent<EnemySettings>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        setNewDestination();
    }

    private void Update()
    {
        timeBeforeFindNewDirection += Time.deltaTime;
        if (timeBeforeFindNewDirection > enemySettings.timeToFindNewDirection
            || (transform.position.x == finalPosition.x && transform.position.z == finalPosition.z))
            setNewDestination();

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        float distancePlayerToPoint = Vector3.Distance(player.position, finalPosition);

        if (distanceToPlayer < enemySettings.maxAvoidDistance)
        {
            setNewDestination();
            enemyAgent.speed = enemySettings.avoidSpeed;
        }
        else
        {
            enemyAgent.speed = enemySettings.moveSpeed;
        }
    }

    private void setNewDestination()
    {
        timeBeforeFindNewDirection = 0;

        Vector3 randomDirection = Random.insideUnitSphere * enemySettings.randomDirectionRange;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, enemySettings.randomDirectionRange, 1);
        finalPosition = hit.position;

        enemyAgent.SetDestination(finalPosition);

        Debug.DrawRay(finalPosition, Vector3.up * 4, Color.green, enemySettings.timeToFindNewDirection);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemySettings.randomDirectionRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemySettings.maxAvoidDistance);
    }
}
