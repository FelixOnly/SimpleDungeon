using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class LevelLoaderScript : MonoBehaviour
{
    /* This is the parameter for the object on 
       the scene which will just rotating around */
    [SerializeField] private GameObject _loadingObject;

    /* This is the parameter for the animation */
    [SerializeField] private Vector3 _startPos;


    private IEnumerator Start (){

        // safe the position  when the scene was already launched
        _startPos = transform.position;

        // Playing the animation for the object on the scene
        LeanTween.rotateAround(_loadingObject,Vector3.forward,360,2.5f).setLoopClamp();

        // Waiting 3 second
        yield return new WaitForSeconds(3f);

        // Moving the windows to down
        LeanTween.moveY(this.gameObject, _startPos.y - 30, 3f).setEaseOutQuad();

    }

    /* This is function just for calling outside */
    public void LoadLevel(int intScene){
        StartCoroutine(SceneLoading(intScene));   
    }


    private IEnumerator SceneLoading(int intScene){
        
        // Starting animation


        // Make the windows visible
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // Move the window to up
        LeanTween.moveY(this.gameObject, _startPos.y, 1f).setEaseOutQuad();

        // Waiting 3 seconds 
        yield return new WaitForSeconds(3f);

        // Loading the new scene 
        AsyncOperation loadingSceneAsync = SceneManager.LoadSceneAsync(intScene);
        
        // Safe the parameters
        PlayerPrefs.SetInt("Deep", PlayerPrefs.GetInt("Deep") + 1);
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 