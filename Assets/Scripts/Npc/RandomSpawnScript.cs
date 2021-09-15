using System.Collections.Generic;
using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class RandomSpawnScript : MonoBehaviour
{
    // This is the list which the game using for spawn items  
    [SerializeField] private List<GameObject> _listSpawn = new List<GameObject>();
    [SerializeField] private GameManager _manager;

    void Start()
    {
        _manager = GameObject.FindObjectOfType<GameManager>();

        // If right now time for spawn a boss
        if(_manager.AsMuchDeep != 3){
            
            /* This is an algorithm which help spawning the items only with chance */

            float rnd = Random.value;
        

            if(rnd > 0.9 ){ //10%
                // Spawning
                Instantiate(original: _listSpawn[2],position: transform.position, rotation: Quaternion.identity, parent: transform);
            }
            else if(rnd > 0.7 ){ //30%
                Instantiate(original: _listSpawn[1],position: transform.position, rotation: Quaternion.identity, parent: transform);
            }
            else if(rnd > 0.3){ //70%
                Instantiate(original: _listSpawn[0],position: transform.position, rotation: Quaternion.identity, parent: transform);
            }
            else //10% NULL
            {
                return;
            }
        }

        
    }

}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 