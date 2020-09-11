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
    public Transform player = null;
    private GameObject[] interceptor = null;
    private InterceptorController interceptorController = null;

    private int interceptorIndex;
    public Transform interceptorTarget = null;
    private Transform fleePoint;

    private Vector3 finalPosition;

    private float timeBeforeFindNewDirection = 0;
    private float distanceToFleePoint;
    private float distanceToInterceptor;
    private int newAction = 0;

    private float timeToAttack = 0;
    private bool foundFleePoint = false;

    #endregion

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemySettings = GetComponent<EnemySettings>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        interceptor = GameObject.FindGameObjectsWithTag("Interceptor");
        interceptorIndex = Random.Range(0, interceptor.Length);
        interceptorTarget = interceptor[interceptorIndex].transform;

        enemyAgent.SetDestination(interceptorTarget.position);
        interceptorController = interceptor[interceptorIndex].GetComponentInParent<InterceptorController>();

        int randomFleePoint = Random.Range(0, enemySettings.fleePoints.Length);
        fleePoint = enemySettings.fleePoints[randomFleePoint];
    }

    private void Update()
    {
        timeToAttack += Time.deltaTime;

        determineBestAction();
    }

    private void determineBestAction()
    {
        distanceToInterceptor = Vector3.Distance(transform.position, interceptorTarget.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        distanceToFleePoint = Vector3.Distance(transform.position, fleePoint.position);

        if ((distanceToInterceptor > enemySettings.attackRange) && (distanceToPlayer > enemySettings.maxAvoidDistance))
        {
            newAction = 0;
        }
        else if (distanceToPlayer <= enemySettings.maxAvoidDistance)
        {
            newAction = 1;
        }
        
        if ((distanceToPlayer > enemySettings.maxAvoidDistance) && (distanceToInterceptor > enemySettings.attackRange))
        {
            newAction = 2;
        }

        StartCoroutine(switchAction(newAction));
    }

    private IEnumerator switchAction(int action)
    {
        yield return new WaitForSeconds(1);

        switch (action)
        {
            case 0:
                //Attack
                if (distanceToInterceptor <= enemySettings.attackRange)
                    attackInterceptor();
                break;
            case 1:
                //Flee
                enemyAgent.SetDestination(fleePoint.position);
                foundFleePoint = true;
                break;
            case 2:
                //Retarget interceptor
                enemyAgent.SetDestination(interceptorTarget.position);
                int randomFleePoint = Random.Range(0, enemySettings.fleePoints.Length);
                fleePoint = enemySettings.fleePoints[randomFleePoint];
                break;
        }

        yield break;
    }

    private void attackInterceptor()
    {
        interceptorController.takeDamage(enemySettings.damage);
        timeToAttack = 0;
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
}
