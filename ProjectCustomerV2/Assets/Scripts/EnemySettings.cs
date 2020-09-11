using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
    #region Variables

    private NavMeshAgent enemyAgent = null;
    private EnemyController enemyController = null;

    [Range(1, 25)]
    public int moveSpeed = 3;
    public int turnSpeed = 300;
    public int avoidSpeed = 2;

    public int attackRange = 15;
    public float maxAvoidDistance = 20f;

    public float randomDirectionRange = 20f;

    public int timeToFindNewDirection = 10;

    [Range(5, 200)]
    public int damage = 20;
    [Range(0.5f, 10f)]
    public float attackSpeed = 10f;

    public Transform[] fleePoints;

    #endregion

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<EnemyController>();

        enemyAgent.speed = moveSpeed;
        enemyAgent.angularSpeed = turnSpeed;
        enemyAgent.stoppingDistance = attackRange;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, randomDirectionRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxAvoidDistance);

        Gizmos.color = Color.white;
        for (int i = 0; i < fleePoints.Length; i++)
            Gizmos.DrawWireSphere(fleePoints[i].position, 3f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, enemyController.player.position);
        Gizmos.DrawLine(transform.position, enemyController.interceptorTarget.position);
    }
}
