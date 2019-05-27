using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Doing nothing, just standing there... menacingly.
/// </summary>
public class FIdle : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        thisFormation = EnumArmyStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControl)
        {

            if(!Input.anyKey)
            {
                ActivateFormation();
            }

        }
        
    }
}
