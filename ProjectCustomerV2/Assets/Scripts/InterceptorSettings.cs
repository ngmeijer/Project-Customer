using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorSettings : MonoBehaviour
{
    #region Variables

    public float health = 100;
    public float maxHealth = 100;
    public float newMaxHealth = 200;

    public float currentTrashAmount = 0;
    public float maxTrashAmount = 200;

    public GameObject objectToChangeMat;

    public List<Color> lightColours = new List<Color>();

    #endregion
}
