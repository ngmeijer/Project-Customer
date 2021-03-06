﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishController : MonoBehaviour
{
    private NavMeshAgent fishAgent = null;
    private FishSettings fishSettings = null;
    private Animator animator = null;

    private float timer;
    [SerializeField] private float findNewDirection = 0;
    private Vector3 point;

    private void Start()
    {
        fishAgent = GetComponent<NavMeshAgent>();
        fishSettings = GetComponent<FishSettings>();
        animator = GetComponent<Animator>();
        generatePosition();

        findNewDirection = Random.Range(fishSettings.minNewDirTime, fishSettings.maxNewDirTime + 1);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= findNewDirection || transform.position == point)
        {
            generatePosition();
            animator.SetTrigger("Jump");
            timer = 0;
        }
    }

    private void generatePosition()
    {
        if (RandomPoint(transform.position, fishSettings.randomDirectionRange, out point))
        {
            fishAgent.SetDestination(point);
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
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
