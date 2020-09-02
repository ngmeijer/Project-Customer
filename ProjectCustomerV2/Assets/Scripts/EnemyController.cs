using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySettings), (typeof(NavMeshAgent)))]
public class EnemyController : MonoBehaviour
{
    private EnemySettings enemySettings = null;
    private NavMeshAgent enemyAgent = null;
    private Transform player = null;

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemySettings = GetComponent<EnemySettings>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        //MOVE AWAY FROM ENEMY INSTEAD OF TOWARDS, DECREASE MOVEMENT SPEED AND FIND RANDOM POINT OUTSIDE THE PLAYER RADIUS
        if (distance <= enemySettings.maxAvoidDistance)
        {
            enemyAgent.speed = enemySettings.avoidSpeed;
        }
        else
        {
            enemyAgent.speed = enemySettings.moveSpeed;
        }
    }
}
