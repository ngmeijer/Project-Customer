using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource bonk = null;
    private AudioSource trashCollected = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            bonk.Play();
            Debug.Log("playing bonk");
        }

        if(collision.gameObject.CompareTag("SmallTrash") || collision.gameObject.CompareTag("BigTrash"))
        {
            trashCollected.Play();
            Debug.Log("playing trash collected");
        }
    }
}
