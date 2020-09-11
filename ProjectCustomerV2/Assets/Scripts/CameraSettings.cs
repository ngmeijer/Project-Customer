using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    #region Variables

    private Camera cam = null;
    public Transform player = null;

    [Range(20, 400)]
    public float scrollSpeed = 200f;
    [Range(1, 40)]
    public int scrollMultiplier = 5;

    public Vector3 offset;
    public Vector3 rotateValue;

    public Vector2 minBorders;
    public Vector2 maxBorders;

    public float cameraHeight = 20;
    public float maxCameraHeight = 50;
    public float minCameraHeight = 10;

    public bool lockOnPlayer = true;
    public bool abilityToZoom = true;
    public bool moveOnZ = false;
    public bool invert = false;
    public int panBorderTreshold = 5;
    public float panSpeed = 5f;

    #endregion
}