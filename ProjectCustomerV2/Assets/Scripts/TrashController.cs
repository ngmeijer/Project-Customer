using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Material dissolveShader = null;

    public IEnumerator handleDeactivation(float pickupTime)
    {
        //GetComponentInChildren<MeshRenderer>().material = dissolveShader;

        yield return new WaitForSeconds(pickupTime);

        gameObject.SetActive(false);

        yield break;
    }
}
