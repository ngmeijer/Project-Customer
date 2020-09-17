using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Material dissolveShader = null;
    [SerializeField] private PlayerStats playerStats = null;
    private TrashGeneratorSettings trashGeneratorSettings = null;
    private NavMeshAgent trashAgent = null;
    public GameObject target = null;
    [SerializeField] private float floatSpeed = 5;
    private Animator animator = null;
    [SerializeField] private float timer = 0;
    [SerializeField] private float timeToDespawn = 10f;
    [SerializeField] private float timeToWarn = 5f;
    public bool shouldDisable = false;
    [SerializeField] GameObject canvas = null;

    private void OnEnable()
    {
        trashGeneratorSettings = FindObjectOfType<TrashGeneratorSettings>();
        animator = GetComponent<Animator>();
        trashAgent = GetComponent<NavMeshAgent>();
        playerStats = FindObjectOfType<PlayerStats>();

        trashAgent.speed = 5;

        if ((target != null) && (trashAgent.isActiveAndEnabled) && (trashGeneratorSettings.floatToTarget))
        {
            trashAgent.SetDestination(target.transform.position);
        }
        else trashAgent.enabled = true;
    }

    private void Update()
    {
        if (!shouldDisable) return;
        else StartCoroutine(disableObject());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndPoint"))
        {
            playerStats.calculateSupporters(-PlayerSettings.supporterDecrement);
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator disableObject()
    {
        timer += Time.deltaTime;

        if (timer >= timeToWarn)
        {
            canvas.SetActive(true);
        }

        if (timer >= timeToDespawn)
        {
            animator.SetTrigger("Sink");
            yield return new WaitForSeconds(1);
            playerStats.calculateSupporters(-PlayerSettings.supporterDecrement);
            canvas.SetActive(false);
            this.gameObject.SetActive(false);
            timer = 0;
        }

        yield break;
    }

    private void OnDisable()
    {
        canvas.SetActive(false);
    }
}
