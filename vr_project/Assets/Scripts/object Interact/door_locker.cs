using UnityEngine;

public class door_locker: MonoBehaviour
{
    public Transform door;
    public Transform keyhole;
    public Transform key;

    private bool isKeyInLocker = false;

    private void Update()
    {
        if (isKeyInLocker)
        {
            //Do something, whatever u want, like do anim or ...

            Debug.Log("door is open");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key)
        {
            isKeyInLocker = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == key)
        {
            isKeyInLocker = false;
        }
    }
}
