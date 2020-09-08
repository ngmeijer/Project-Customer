using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorSettings : MonoBehaviour
{
    #region Variables

    public int health = 100;
    public int maxHealth = 100;

    public float currentTrashAmount = 0;
    public float maxTrashAmount = 200;

    public List<Color> lightColours = new List<Color>();

    #endregion
}
