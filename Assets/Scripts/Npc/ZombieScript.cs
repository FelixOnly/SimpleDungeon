using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class ZombieScript : MonoBehaviour, ICreature, IDamageable<int>, IKillable
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

    private void Update() {
        
        if(Heath == 0){
            
            Kill();
        }
    }

    public void InDamage(int damageVariable)
    {
        Heath -= damageVariable;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
        Destroy(this.GetComponent<NpcControl>().MovingPoint.gameObject);
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 