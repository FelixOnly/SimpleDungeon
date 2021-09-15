using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class SupportScript : MonoBehaviour
{   
    /* the parameters which will add to the player parameter */
    [SerializeField] private int _newHp;
    [SerializeField] private int _newDamage;

    private void OnCollisionEnter2D(Collision2D other) {

        // If this the collision are the player
        if(other.gameObject.tag == "Player"){
            
            // Add to the player new the parameters 
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Heath += _newHp;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().GetComponent<IDamageable<int>>().OutDamage += _newDamage;

            // Destroy this is the object
            Destroy(obj: this.gameObject);

        }
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 