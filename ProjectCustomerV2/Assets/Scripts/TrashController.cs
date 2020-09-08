using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Material dissolveShader = null;

    private NavMeshAgent trashAgent = null;

    private GameObject target = null;

    [SerializeField] private float floatSpeed;

    private void OnEnable()
    {
        trashAgent = GetComponent<NavMeshAgent>();

        trashAgent.speed = floatSpeed;

        target = GameObject.FindGameObjectWithTag("Interceptor");

        if (target != null)
        {
            trashAgent.SetDestination(target.transform.position);
        }
    }

    public IEnumerator handleDeactivation(float pickupTime)
    {
        GetComponentInChildren<MeshRenderer>().material = dissolveShader;

        yield return new WaitForSeconds(pickupTime);

        gameObject.SetActive(false);

        yield break;
    }
}
