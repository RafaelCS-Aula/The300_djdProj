using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Very fast movement forward, leaves army vulnerable to damage
/// </summary>
public class FCharge : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        thisFormation = EnumArmyStates.Charge; 
      
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (playerControl)
        {

            if(Input.GetAxis("Charge") > 0)
            {
                ActivateFormation();
            }

        }
        
    }

    
}
