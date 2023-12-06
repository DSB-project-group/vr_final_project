////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : Jeremy Almonte
//Created On : 9/7/2023
//Description : Simple script to load scene from their build index or load next scene
//Modified On: 12/3/2023 to add a scene fade in and out animation
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private Animator Fade;
    [SerializeField]
    private float FadeTime; 

    public void SceneToLoad(int scene){
        StartCoroutine(LoadSceneWithFade(scene));
    }
    public void LoadNextScene(){
        StartCoroutine(LoadSceneWithFade(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadSceneWithFade(int scene)
    {
        Fade.SetTrigger("Fade");

        yield return new WaitForSeconds(FadeTime);

        SceneManager.LoadScene(scene);
    }
}
