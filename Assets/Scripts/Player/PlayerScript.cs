using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class PlayerScript : MonoBehaviour, ICreature, IDamageable<int>, IKillable
{
    [SerializeField] private int _heath;
    [SerializeField] private int _maxheath;
    [SerializeField] private int _outdamage;


    public int Heath
    {
        get
        {
            return _heath;
        }
        set
        {
            if (value <= 0)
            {
                _heath = 0;
            }
            else if(value >= MaxHeath)
            {
                _heath = MaxHeath;
            }else
            {
                _heath = value;
            }

        }
    }

    public int OutDamage
    {
        get
        {
            return _outdamage;
        }
        set
        {
            if (value <= 0)
            {
                _outdamage = 0;
            }
            else
            {
                _outdamage = value;
            }

        }
    }

    public int MaxHeath
    {
        get
        {
            return _maxheath;
        }
        set
        {
            if (value <= 0)
            {
                _maxheath = 0;
            }
            else
            {
                _maxheath = value;
            }

        }
    }

    public void InDamage(int damageVariable)
    {
        Heath -= damageVariable;
    }
    private void Update() {
        
        if(Heath == 0){
            
            Kill();
        }
    }
    
    public void Kill()
    {
        GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverScript>().ShowingWindow();

        Destroy(this.gameObject);
    }

    public void MovingTo()
    {
        throw new System.NotImplementedException();
    }
    
    private void Start() {

        // Loading all the parameters about the player

        Heath =  PlayerPrefs.GetInt("Heath");
        OutDamage =  PlayerPrefs.GetInt("Damage");
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 