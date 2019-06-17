using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mother class to all the kind of formations an army can take.
/// \
/// Storing all stats.
/// </summary>
[CreateAssetMenu(fileName = "New Formation", menuName = "Game/New Formation")]
public class Formation : ScriptableObject
{
    public EnumArmyFormations Designation;

    [Range(0,2)]
    public float SpeedModifier = 1;

    [Range(0,2)]
    public float AttackModifier = 1;

    [Range(0,2)]
    public float DefenseModifier = 1;

    [Range(0,2)]
    public float MassModifier = 1;





   
}
