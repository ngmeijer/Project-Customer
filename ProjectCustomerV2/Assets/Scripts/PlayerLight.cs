using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light inventoryLight = null;

    [SerializeField] private List<Color> lightColours = new List<Color>();

    private int lightLevel = 0;

    public void updateLightColor(float percentFilled)
    {
        inventoryLight.intensity = 100;
        percentFilled *= 100;

        if (percentFilled <= 25)
        {
            lightLevel = 0;
        }
        else if (percentFilled > 25 && percentFilled <= 50)
        {
            lightLevel = 1;
        }
        else if (percentFilled > 50 && percentFilled <= 75)
        {
            lightLevel = 2;
        }
        else if (percentFilled > 75 && percentFilled <= 100)
        {
            lightLevel = 3;
        }

        switch (lightLevel)
        {
            case 0:
                inventoryLight.color = lightColours[0];
                break;
            case 1:
                inventoryLight.color = lightColours[1];
                break;
            case 2:
                inventoryLight.color = lightColours[2];
                break;
            case 3:
                inventoryLight.color = lightColours[3];
                break;
        }
    }
}
