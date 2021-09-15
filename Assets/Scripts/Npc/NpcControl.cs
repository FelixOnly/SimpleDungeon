using System.Collections;
using UnityEngine;


//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class NpcControl : MonoBehaviour
{

    /* Caching parameters for quickly using 
       and make code more understandable    */
    [Header("Caching parameters")]
    [SerializeField] private Transform _player;
    [SerializeField] private GameManager _manager;


    /* Moving parameters which help moving 
       character on needeed direction       */
    [Header("Moving")]
    [SerializeField] private float _movingspeed;
    public Transform MovingPoint;
    public Transform[] Points;
    public LayerMask DoNotMovingHere;


    /* This is parameters which as well 
       need but not have special topic  */
    [Header("Others")]
    public GameObject HealthBarPrefab;
    public bool ActiveForAttack;




    void Start()
    {   
        // Caching the player and using for it the tag
        _player = GameObject.FindGameObjectWithTag(tag: "Player").GetComponent<Transform>();
        
        // Caching the Game manager and using for it the tag
        _manager = GameObject.FindGameObjectWithTag(tag: "GameController").GetComponent<GameManager>();
        
        // Caching the canvas for make code more understandable
        Transform canvas = GameObject.FindGameObjectWithTag(tag: "GameCanvas").GetComponent<Transform>();

        // Creating the Health bar on the canvas
        GameObject healthBar = Instantiate(original: HealthBarPrefab, position: transform.position, rotation: Quaternion.identity, parent: canvas);
        
        // Change the target on the health bar
        healthBar.GetComponent<HeathBarScript>().Target = this.transform;

        // Nullify the parent of the character
        MovingPoint.parent = null;

        // Start a animation 
        StartCoroutine(routine: TakingDamageAnimation());
    }



    void Update()
    {
        // Anytime moving the character to a point for making moving to the direction  
        transform.position = UnityEngine.Vector3.MoveTowards(current: transform.position, target: MovingPoint.position, maxDistanceDelta: _movingspeed * Time.deltaTime);


        // The game flipping a sprite for making more a cool animation of moving
        if (MovingPoint.position.y > transform.position.y || MovingPoint.position.x > transform.position.x)
        {   
            // flip a sprite 
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (MovingPoint.position.y < transform.position.y || MovingPoint.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }


    }

    /// <summary>
    /// This is animation when the character close to a player, 
    /// character will making animation. This loop will waiting  
    /// when a boolean parameter will true and then it will playing the animation
    /// </summary>
    private IEnumerator TakingDamageAnimation(){

        // Infinity loop
        while (true)
        {
            // If the player change the parameter
            if(ActiveForAttack)
            {
                // Animation
                LeanTween.rotateZ(gameObject: this.gameObject, to: 10, time: 0.5f).setEaseOutQuad();

                // Waiting
                yield return new WaitForSeconds(seconds: 0.5f);

                LeanTween.rotateZ(gameObject: this.gameObject, to: -10, time: 0.5f).setEaseOutQuad();

                yield return new WaitForSeconds(seconds: 0.5f);
            }
            else
            {
                // Return to zero position
                LeanTween.rotateZ(gameObject: this.gameObject, to: 0, time: 0.5f).setEaseOutQuad();
            }

            // Waiting when will the last frame
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// This function  need for making attack on the character 
    /// from the player, and checking about opportunity 
    /// </summary>
    private void OnMouseDown() {
        
        // Calculate the distance between player and character
        int distanceToPlayer = Mathf.RoundToInt(f: UnityEngine.Vector3.Distance(a: _player.position, b: transform.position));

        // If the player close to the character, and if this is the player time for step
        if(distanceToPlayer <= 1 && _manager.GameStape == StepMode.PlayerTurn){
            
            // the game take as much the player has damage and give it to the character
            this.GetComponent<IDamageable<int>>().InDamage(damageVariable: _player.GetComponent<IDamageable<int>>().OutDamage);

            // Change the step in the game
            _manager.GameStape = StepMode.EnemyTurn;

        }
    }

    /// <summary>
    /// This is function for make the character will trying found 
    /// a good way to the player. The game will compare distance 
    /// and opportunity going to direction
    /// </summary>
    public void Action()
    {
        // calculation distance between player and character 
        int distanceToPlayer = Mathf.RoundToInt(f: UnityEngine.Vector3.Distance(a: _player.position, b: transform.position));

        // If the player not close to the character 
        if(distanceToPlayer > 1){

            /* This is algorithm the bubble sort. The game 
               compare distance and opportunity to moving  */

            Transform CachePoint;
            
            for (int i = 0; i < Points.Length - 1; i++)
            {
                for (int j = 0; j < Points.Length - 1; j++)
                {
                    // Compare distance and opportunity
                    if(UnityEngine.Vector3.Distance(a: _player.position, b: Points[j].position) > UnityEngine.Vector3.Distance( a: _player.position, b: Points[j + 1].position)
                    && Physics2D.OverlapCircle(point: Points[j].position, radius: 0.2f, layerMask: DoNotMovingHere) == null ){
                      
                        CachePoint = Points[j + 1];
                        Points[j + 1] = Points[j];
                        Points[j] = CachePoint;
                    }
                }
            }
            
            // If the direction can moving then the character moving to this direction 

            for (int i = 0; i < Points.Length; i++)
            {
                // Check the collision where are the character can't moving
                if(!Physics2D.OverlapCircle( point: Points[i].position, radius: 0.2f, layerMask: DoNotMovingHere)){

                    // Moving the point
                    MovingPoint.position = Points[i].position;
                    break;
                }
            }
        }
        // If the player close to the character, then the character will attack the player
        else if(distanceToPlayer <= 1)
        {
            // Attack
            _player.GetComponent<IDamageable<int>>().InDamage(damageVariable: GetComponent<IDamageable<int>>().OutDamage);
        }
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 