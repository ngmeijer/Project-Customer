using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSettings : MonoBehaviour
{
    #region Variables

    [Range(5, 80)]
    public int randomDirectionRange = 10;
    public float timeBeforeFindNewDirection = 0;

    public int minNewDirTime;
    public int maxNewDirTime;

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, randomDirectionRange);
    }
}
