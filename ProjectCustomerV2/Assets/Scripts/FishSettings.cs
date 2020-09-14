using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSettings : MonoBehaviour
{
    #region Variables

    [Range(5, 80)]
    public int randomDirectionRange = 10;
    public float timeBeforeFindNewDirection = 0;

    [Range(1, 5)]
    public float minNewDirTime;
    [Range(6, 10)]
    public float maxNewDirTime;

    #endregion
}
