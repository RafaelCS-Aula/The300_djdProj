using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles control of the player's army
/// \
/// Uses Input to determine formations
/// </summary>
public class PlayerControl : Controller
{
 

    public override Formation ChooseFormation()
    {


        // If left arrow, brace
        if(Input.GetKey(KeyCode.LeftArrow) && brace != null) return brace; 
        // if down arrow, cover
        else if(Input.GetKey(KeyCode.DownArrow) && cover != null) return cover;
        // if right arrow, march
        else if(Input.GetKey(KeyCode.RightArrow) && march != null) return march;
        // if up arrow, charge
        else if(Input.GetKey(KeyCode.UpArrow) && charge != null) return charge;
        

        if(Input.GetKey(KeyCode.X)) 
        {
            armyScript.Attack();
            return idle;

        }
        else return idle;


    }
}
