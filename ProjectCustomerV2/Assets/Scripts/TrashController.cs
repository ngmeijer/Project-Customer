using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Material dissolveShader = null;

    private TrashGeneratorSettings trashGeneratorSettings = null;

    private NavMeshAgent trashAgent = null;

    public GameObject target = null;

    [SerializeField] private float floatSpeed = 5;

    private void OnEnable()
    {
        trashGeneratorSettings = FindObjectOfType<TrashGeneratorSettings>();

        trashAgent = GetComponent<NavMeshAgent>();

        trashAgent.speed = 5;

        if ((target != null) && (trashAgent.isActiveAndEnabled) && (trashGeneratorSettings.floatToTarget))
        {
            trashAgent.SetDestination(target.transform.position);
        }
        else trashAgent.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndPoint"))
        {
            this.gameObject.SetActive(false);
        }
    }

    //public IEnumerator handleDeactivation(float pickupTime)
    //{
    //    //GetComponentInChildren<MeshRenderer>().material = dissolveShader;

    //    yield return new WaitForSeconds(pickupTime);

    //    gameObject.SetActive(false);

    //    yield break;
    //}
}
