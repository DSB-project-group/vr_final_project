using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRObjectInteraction : MonoBehaviour
{
    public FireBullet fireBulletScript;

    private bool isHeld = false;

    // Logic for picking up the object with XR interaction
    public void PickUpObject()
    {
        isHeld = true;
        // Disable firing while object is held
        fireBulletScript.enabled = false;
    }

    // Logic for releasing the object
    public void ReleaseObject()
    {
        isHeld = false;
        // Re-enable firing when the object is released
        fireBulletScript.enabled = true;
    }

    // Other XR interaction methods as needed
}
