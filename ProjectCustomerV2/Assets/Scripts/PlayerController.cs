using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent playerAgent = null;

    [SerializeField] private Camera playerCamera = null;

    private void Start()
    {
        if (playerAgent != null)
        { return; }
        else if (playerAgent == null)
        { playerAgent = GetComponent<NavMeshAgent>(); }
        else { Debug.Assert(playerAgent != null, "The NavMeshAgent of the player is not attached to " + gameObject.name); }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                playerAgent.SetDestination(hit.point);
            }
        }
    }
}
