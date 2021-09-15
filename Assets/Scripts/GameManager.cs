using System.Linq;
using System.Collections;
using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

/// <summary>
/// This parameter will change with situation in the game
/// </summary>
public enum StepMode { PlayerTurn, EnemyTurn, NoFight }

public class GameManager : MonoBehaviour
{   
    // Parameter for show a window only when a player launch the game first time
    [SerializeField] private static bool _wasWelcome;
    
    // Parameter about deep in the game
    public int AsMuchDeep;

    // Main parameter in the game and making the game as chess 
    public StepMode GameStape;

    private void Awake() 
    {
        // Safe the parameter about deep every time when scene launched
        AsMuchDeep = PlayerPrefs.GetInt(key: "Deep");
    }
    void Start()
    {

        // Destroy the window when scene starting and if the player already saw it 
        if(_wasWelcome){
            Destroy(GameObject.FindGameObjectWithTag(tag: "Welcome"));
        }
        
        // This is will working all time in the scene
        StartCoroutine(routine: CycleOfMoving());
    }

    private IEnumerator CycleOfMoving(){

        // Infinite loop
        while(true){
            
            // If the scene not have enemies the player will moving without stop
            if(GameObject.FindGameObjectsWithTag(tag: "Enemy").Count() == 0)
            {
                // The parameter change about the game mode 
                GameStape = StepMode.NoFight;
            }
            else
            {
                // The game have a enemies 

                // The parameter change the game mode on the player turn 
                GameStape = StepMode.PlayerTurn;

                // Waiting when he will making step, and the game waiting  
                while(GameStape == StepMode.PlayerTurn){

                    yield return new WaitForEndOfFrame();
                }
                
                // The Player was make step
                

                // Begin the enemies turn
                GameStape = StepMode.EnemyTurn;

                // The game waiting a bit
                yield return new WaitForSeconds(0.1f);

                // Every the enemy making step  
                foreach (var Enemy in GameObject.FindGameObjectsWithTag(tag: "Enemy"))
                {
                    // The enemy making action
                    Enemy.GetComponent<NpcControl>().Action();

                    // A bit waiting
                    yield return new WaitForSeconds(0.8f);

                }

                // Begin the player turn
            }
            
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// When the player press button "Play" we change 
    /// parameter and now the player don't will see this window
    /// </summary>
    public void WelcomeSetOn(){
        _wasWelcome = true;
    }

    // We restore parameters 
    private void OnApplicationQuit() {
        
        PlayerPrefs.SetInt(key: "Deep",   value: 0);
        PlayerPrefs.SetInt(key: "Heath",  value: 5);
        PlayerPrefs.SetInt(key: "Damage", value: 1);
        _wasWelcome = false;
        
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021