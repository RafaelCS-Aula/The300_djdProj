using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mother class to all the kind of formations an army can take.
/// \
/// Storing all stats.
/// </summary>
public abstract class Formation : MonoBehaviour
{
    protected Army armyScript;

    [SerializeField]
    protected float speedMod;

    [SerializeField]
    protected float atkMod;

    [SerializeField]
    protected float defMod;

    [SerializeField]
    protected float massMod;

    protected EnumArmyStates thisFormation;

    [SerializeField]
    protected bool playerControl = true;

    protected void Start()
    {
        armyScript = GetComponent<Army>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMod = Mathf.Clamp(speedMod, 0, 2);
        atkMod = Mathf.Clamp(atkMod, 0, 1);
        defMod = Mathf.Clamp(defMod, 0, 1);
        massMod = Mathf.Clamp(massMod, 0, 1);
    }

    /// <summary>
    /// Access the army script of the GameObject and apply to it the values
    /// established here.
    /// </summary>
    public void ActivateFormation()
    {
        armyScript.currentState = thisFormation;
        armyScript.defenseModifier = defMod;
        armyScript.speedModifier = speedMod;
        armyScript.attackModifier = atkMod;
        armyScript.massModifier = massMod;

    }

    public void SetControllable(bool controllable) => playerControl = controllable;
   
}
