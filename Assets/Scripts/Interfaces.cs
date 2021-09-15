//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

/// <summary> 
/// Interface for getting damage this 
/// help for make code more simple
/// </summary>
/// <typeparam name="T">Int damage</typeparam>
public interface IDamageable<T>
{
    /// <summary>
    /// Function for getting damage
    /// </summary>
    /// <param name="damageVariable">Int Damage</param>
    void InDamage(T damageVariable);

    /// <summary>
    /// Parameter which for giving damage to an object which have IDamageable
    /// </summary>
    /// <value></value>
    int OutDamage { get; set;}
}

/// <summary>
/// Interface for destroying an object or other functions
/// for help make code more simple
/// </summary>
public interface IKillable
{
    /// <summary>
    /// Write here actions if the character  
    /// takes enough damage to accept death
    /// </summary>
    void Kill();
}

/// <summary>
/// Interface for having usual parameters for the creature 
/// </summary>
public interface ICreature
{
    int Heath { get; set; }
    int MaxHeath { get; set; }

}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 