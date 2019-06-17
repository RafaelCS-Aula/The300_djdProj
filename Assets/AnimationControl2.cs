using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl2 : MonoBehaviour
{
    Army armyScript;
    private Animator anim;
    EnumArmyFormations currentFormationName;

    void Start()
    {
        armyScript = GetComponentInParent<Army>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (armyScript == null || armyScript.activeFormation == null)
            return;

        currentFormationName = armyScript.activeFormation.Designation;

        anim.SetBool("Cover", currentFormationName == EnumArmyFormations.Cover);
        anim.SetBool("Moving", currentFormationName == EnumArmyFormations.March);
        anim.SetBool("Charging", currentFormationName == EnumArmyFormations.Charge);
        anim.SetBool("Bracing", currentFormationName == EnumArmyFormations.Brace);

        //anim.SetBool("Attack", armyScript.isAttacking);
    }
}
