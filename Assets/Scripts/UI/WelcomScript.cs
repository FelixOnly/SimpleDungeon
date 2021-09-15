using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class WelcomScript : MonoBehaviour
{
    /* This is function only for make animation 
       when the player close the window            */
    public void ClosePanel()
    {
        // Moving the window down and in the end just destroy the window
        LeanTween.moveY(this.gameObject, -20, 1.5f).setEaseOutQuad().setOnComplete(() => {
            Destroy(this.gameObject);
        });
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 