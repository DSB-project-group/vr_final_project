using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light lightp;

    void Start()
    {
        lightp = GetComponentInChildren<Light>();
    }
    public void LightOn()
    {
        lightp.enabled = true;
    }

    public void LighOff()
    {
        lightp.enabled = false;
    }

}
