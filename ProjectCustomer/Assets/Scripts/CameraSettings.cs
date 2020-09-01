﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    #region Variables
    
    [Range(20, 400)]
    public float scrollSpeed = 200f;
    [Range(1, 40)]
    public int scrollMultiplier = 5;

    #endregion

}