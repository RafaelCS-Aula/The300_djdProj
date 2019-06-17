using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mother class for the Player and Enemy
/// \
/// Characters control armies by changing their formations
/// according to the rules set in this script's chidlren
/// </summary>
[RequireComponent(typeof(Army))]
public abstract class Controller : MonoBehaviour
{
    [SerializeField] protected  Army armyScript;
    [SerializeField]protected  List<Formation> possibleFormations = new List<Formation>();

    // Keep a reference to all the formation scriptable objects
    internal Formation charge = null;
    internal Formation brace = null;
    internal Formation cover = null;
    internal Formation march = null;
    internal Formation idle = null;
    internal Formation attack = null;
        
    private void Awake() 
    {
        foreach (Formation f in possibleFormations)
        {
            if(f.Designation.Equals(EnumArmyFormations.Charge)) charge = f;
            else if(f.Designation.Equals(EnumArmyFormations.Brace)) brace = f;
            else if(f.Designation.Equals(EnumArmyFormations.Cover)) cover = f;
            else if(f.Designation.Equals(EnumArmyFormations.March)) march = f;
            else if(f.Designation.Equals(EnumArmyFormations.Idle)) idle = f;
            else if (f.Designation.Equals(EnumArmyFormations.Attack)) attack = f;
        }

        armyScript.activeFormation = possibleFormations[0];
    }

    public abstract Formation ChooseFormation();

    // Update is called once per frame
    protected virtual void Update()
    {
        Formation c = ChooseFormation();
        if (c == null)
            return;

        armyScript.activeFormation = c;
        
    }
}
