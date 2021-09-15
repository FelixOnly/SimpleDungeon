using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class GameOverScript : MonoBehaviour
{   
    /* This is the parameter for show the 
       text only when the player see the window */
    [SerializeField] private GameObject _text;

    /* This is the parameter for animation  */
    [SerializeField] private Vector3 _startPos;
    
    
    void Start()
    {
        // safe the position when the scene already launched
        _startPos = transform.position;

        // Moving the window to down
        LeanTween.moveY(this.gameObject, _startPos.y - 30, 3f).setEaseOutQuad();
    }
    
    /// <summary>
    /// This is function for moment when the player 
    /// already die, and he triggers this function 
    /// and after will playing animation 
    /// </summary>
    public void ShowingWindow(){
        
        /* Make the window visible */
        CanvasGroup cGroup = GetComponent<CanvasGroup>();

        cGroup.alpha = 1;
        cGroup.blocksRaycasts = true;
        cGroup.interactable = true;

        // moving the window to the start position 
        LeanTween.moveY(this.gameObject, _startPos.y, 3f).setEaseOutQuad();

        // Show the text for begin the animation 
        _text.SetActive(true);
    }

    /// <summary>
    /// This is function when player 
    /// wanna continue play in the game and
    /// wanna restart the game
    /// </summary>
    public void RestartGame(){
        
        // safe the parameters
        PlayerPrefs.SetInt("Deep", -1);
        PlayerPrefs.SetInt("Heath", 5);
        PlayerPrefs.SetInt("Damage", 1);

        // Loading the scene 
        GameObject.FindGameObjectWithTag("LevelLouder").GetComponent<LevelLoaderScript>().LoadLevel(0);
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 