using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class PlayerControl : MonoBehaviour
{
     /* Moving parameters which help moving 
       character on needeed direction       */
    [Header("Moving")]
    [SerializeField] private float _movingspeed;
    [SerializeField] private Transform _movingpoint;
    private GameManager _manager;
    public LayerMask DoNotMovingHere;

    /* This is parameters which as well 
       need but not have special topic  */
    [Header("Other")]
    public GameObject HealthBarPrefab;

    
    
    

    void Start()
    {
        // Caching the Game manager and using for it the tag
        _manager = GameObject.FindGameObjectWithTag(tag: "GameController").GetComponent<GameManager>();

        // Nullify the parent of the character
        _movingpoint.parent = null;

        // Caching the canvas for make code more understandable
        Transform canvas = GameObject.FindGameObjectWithTag(tag: "GameCanvas").GetComponent<Transform>();
        
        // Creating the Health bar on the canvas
        GameObject healthBar = Instantiate( original: HealthBarPrefab, position: transform.position, rotation: Quaternion.identity, parent: canvas);

        // Change the target on the health bar
        healthBar.GetComponent<HeathBarScript>().Target = this.transform;
    }

    void Update()
    {
        //the character moving to point
        transform.position = Vector3.MoveTowards(current: transform.position, target: _movingpoint.position, maxDistanceDelta: _movingspeed * Time.deltaTime);


        // If right now turn are enemy then the game don't let the player moving
        if(_manager.GameStape == StepMode.PlayerTurn || _manager.GameStape == StepMode.NoFight){

            /* Playing animation on enemy about opportunity attack, the game found 
               all enemies and check distance between the player and the enemy, and if the enemy 
               are close then we change the boolean parameter in the enemy                       */

            // Take all the enemies on the scene
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag: "Enemy");
            
            // Loop for every the enemy 
            foreach (var Enemy in enemies)
            {
                // Calculation the distance between the enemy and the player
                int distanceToEnemy = Mathf.RoundToInt(f: UnityEngine.Vector3.Distance(this.transform.position, Enemy.transform.position));

                // If the enemy are close
                if(distanceToEnemy == 1)
                {
                    // change the parameter in the enemy
                    Enemy.GetComponent<NpcControl>().ActiveForAttack = true;
                }
                else
                {
                    Enemy.GetComponent<NpcControl>().ActiveForAttack = false;
                }
                
            }


            // The game flipping a sprite for making more a cool animation of moving
            if (Input.GetAxisRaw( axisName:"Horizontal") == 1f || Input.GetAxisRaw( axisName: "Vertical") == 1f)
            {
                // flip a sprite 
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetAxisRaw( axisName: "Horizontal") == -1f || Input.GetAxisRaw( axisName: "Vertical") == -1f )
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }


            /* The game get direction which the player wanna move 
               and after the game moving the point to direction, 
               and after already the player moving to this point  */

            // If the position the moving point has been changed 
            if (Vector3.Distance( a: transform.position, b: _movingpoint.position) <= 0.05f)
            {
                // This is the direction are Horizontal
                if (Mathf.Abs(Input.GetAxisRaw( axisName: "Horizontal")) == 1f)
                {
                    // Check the point and if in this place are collision which the player can't moving 
                    if (!Physics2D.OverlapCircle(point: _movingpoint.position + new Vector3(Input.GetAxisRaw( axisName: "Horizontal"), 0f, 0f), radius: 0.2f, layerMask: DoNotMovingHere))
                    {
                        // Change the position to the moving point to the direction
                        _movingpoint.position += new Vector3(x: Input.GetAxisRaw( axisName: "Horizontal"), y: 0f, z: 0f);
                        
                        // Change the game stape to the enemy 
                        if(_manager.GameStape != StepMode.NoFight)
                            _manager.GameStape = StepMode.EnemyTurn;
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw( axisName: "Vertical")) == 1f)
                {

                    if (!Physics2D.OverlapCircle(point: _movingpoint.position + new Vector3(0f, Input.GetAxisRaw( axisName: "Vertical"), 0f), radius: 0.2f, layerMask: DoNotMovingHere))
                    {
                        _movingpoint.position += new Vector3(x: 0f, y: Input.GetAxisRaw( axisName: "Vertical"), z: 0f);
                        
                        if(_manager.GameStape != StepMode.NoFight)
                            _manager.GameStape = StepMode.EnemyTurn;
                    }
                }

            }
        } 
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 