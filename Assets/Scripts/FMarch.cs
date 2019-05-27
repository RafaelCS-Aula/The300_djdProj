using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Standar movement forward.
/// </summary>
public class FMarch : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        thisFormation = EnumArmyStates.March;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl)
        {

            if(Input.GetAxis("Horizontal") != 0)
            {
                ActivateFormation();
            }

        }        
    }

}
