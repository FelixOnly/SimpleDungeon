using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

/// <summary>
/// This is a script that spawning boss on 
/// a level when the player on a special deep level
/// </summary>
public class BossSpawner : MonoBehaviour
{
    // Caching the parameter
    [SerializeField] private GameManager _manager;
    
    // the prefab object which the game should spawn 
    public GameObject BossPrefab;


    void Start()
    {
        // Caching the parameter
        _manager = GameObject.FindObjectOfType<GameManager>();

        // When the player on 3 the deep level a script will spawning the boss 
        if(_manager.AsMuchDeep == 3){
            Instantiate(original: BossPrefab, position: transform.position, rotation: Quaternion.identity, parent: transform);
        }
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 