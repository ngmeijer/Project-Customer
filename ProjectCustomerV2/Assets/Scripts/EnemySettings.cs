using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
    #region Variables

    private NavMeshAgent enemyAgent = null;

    public float maxAvoidDistance = 20f;
    public int moveSpeed = 3;
    public int turnSpeed = 300;
    public int avoidSpeed = 2;

    public float randomDirectionRange = 20f;

    public int timeToFindNewDirection = 10;

    #endregion

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

        enemyAgent.speed = moveSpeed;
        enemyAgent.angularSpeed = turnSpeed;
    }
}
