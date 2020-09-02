using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Material dissolveShader = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //StartCoroutine(handleDeactivation());
        }
    }

    private IEnumerator handleDeactivation()
    {
        GetComponentInChildren<MeshRenderer>().material = dissolveShader;

        yield return new WaitForSeconds(1);


        yield break;
    }
}
