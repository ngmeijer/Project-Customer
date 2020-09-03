using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraSettings cameraSettings = null;

    [SerializeField] private Transform player = null;

    private void Start()
    {
        cameraSettings = GetComponent<CameraSettings>();
    }

    private void Update()
    {
        transform.position = player.position + cameraSettings.offset;

        

        transform.LookAt(player);

        handleCameraZoom();
    }

    private void handleCameraZoom()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        if ((cameraSettings.offset.y < cameraSettings.maxCameraHeight) && (cameraSettings.offset.y > cameraSettings.minCameraHeight))
        {
            cameraSettings.offset.y += scrollValue * -cameraSettings.scrollSpeed * cameraSettings.scrollMultiplier * Time.deltaTime;
        }
        else
        { 
            if (cameraSettings.offset.y > cameraSettings.maxCameraHeight)
            {
                cameraSettings.offset.y = cameraSettings.maxCameraHeight - 0.5f;
            }
            else if (cameraSettings.offset.y < cameraSettings.minCameraHeight)
            {
                cameraSettings.offset.y = cameraSettings.minCameraHeight + 0.5f;
            }
        }
    }
}