using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string scenename;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(scenename);
        }
    }


    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
