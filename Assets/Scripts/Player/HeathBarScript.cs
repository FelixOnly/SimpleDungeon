using System.Collections.Generic;
using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class HeathBarScript : MonoBehaviour
{
    /* This is the list to control count */
    [SerializeField] private List<GameObject> Points = new List<GameObject>();
    
    /* Cache to make code more understandable */
    [SerializeField] private GameManager _manager;
    
    /* This is the parameter for using it like the target which is the character */
    private ICreature _creature;

    /* This is a prefab for spawn */
    public GameObject ExampleOfHeath; 

    /* This is the parameter for using it as the position */
    public Transform Target;




    private void Start() 
    {
        // Caching the parameters 

        _creature = Target.GetComponent<ICreature>();
        _manager = GameObject.FindGameObjectWithTag(tag: "GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        // If right now not a fight then the game make the Heath bar invisible

        if(_manager.GameStape == StepMode.NoFight)
        {
            // make invisible all object
            GetComponent<CanvasGroup>().alpha = 0;

            // Make invisible the heath points
            foreach (var Point in Points)
            {
                Point.SetActive(value: false);
            }

            return;
        }
        else
        {
            // Other way 

            // make visible all object
            GetComponent<CanvasGroup>().alpha = 1;

            // Make visible the heath points
            foreach (var Point in Points)
            {
                Point.SetActive(value: true);
            }
        }


        // If the game destroyed the target then the heath bar as well will destroy himself
        if(!Target)
        {
            Destroy(obj: this.gameObject);
            return;
        }

        // The heath bar will moving only with the target
        transform.position = Target.position;


        // If the heath bar not have same count for the heath object
        if(Points.Count != _creature.Heath)
        {

            // the game destroy every the heath points
            foreach (var HeathPoint in Points)
            {
                Destroy(obj: HeathPoint);
            }
            
            // clear the list
            Points.Clear();

            for (int i = 0; i < _creature.Heath; i++)
            {
                // Spawn new the heath points 
                GameObject newHeath = Instantiate(original: ExampleOfHeath, position: transform.position, rotation: Quaternion.identity, parent: transform);

                Points.Add(item: newHeath);
            }
            

        }


        
    }
   
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 