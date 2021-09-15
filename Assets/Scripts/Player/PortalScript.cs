using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class PortalScript : MonoBehaviour
{   
    /* The object on the scene which will showing 
       when the player close to the portal        */
    [SerializeField] private GameObject _interactUi;

    /* This is parameter about which 
       will launching the scene          */
    public int ToScene;


    void OnTriggerEnter2D(Collider2D other)
    {
        // If collider are the player
        if(other.tag == "Player"){
            // Show the object 
            _interactUi.SetActive(value: true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        // If collider are the player and If the player press button "E"
        if(other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            // Safe the parameter for next the scene
            PlayerPrefs.SetInt(key: "Heath", value: other.GetComponent<ICreature>().Heath);
            PlayerPrefs.SetInt(key: "Damage",value:  other.GetComponent<IDamageable<int>>().OutDamage);

            // Load the next scene
            GameObject.FindGameObjectWithTag( tag: "LevelLouder").GetComponent<LevelLoaderScript>().LoadLevel(intScene: ToScene);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        // If collider are the player
        if(other.tag == "Player"){
            // hide the object 
            _interactUi.SetActive(value: false);
        }
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 