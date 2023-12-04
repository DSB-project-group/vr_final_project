using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;
    public AudioClip fireSound;

    private AudioSource audioSource; // Added AudioSource reference
    private bool firstCallIgnored = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    public void Fire()
    {
        if (!firstCallIgnored)
        {
            firstCallIgnored = true;
            return;
        }

        Debug.Log("Fire");
        if (fireSound != null && audioSource != null)
        {
            Debug.Log("Playing Fire Sound");
            audioSource.PlayOneShot(fireSound);
        }

        GameObject spawnedBullet = Instantiate(bulletObj, frontOfGun.position, frontOfGun.rotation);
        Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>(); // Get the Rigidbody component
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = speed * frontOfGun.forward; // Set velocity for the bullet
        }

        Destroy(spawnedBullet, 5f); // Destroy the bullet after 5 seconds
    }
}
