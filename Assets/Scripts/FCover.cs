using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Most defensive position possible, guards agains't projectiles.!--
/// But can't move while on it.
/// </summary>
public class FCover : Formation
{

   
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        thisFormation = EnumArmyStates.Cover;        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (playerControl)
        {

            if(Input.GetAxis("Cover") > 0)
            {
                ActivateFormation();
            }

        }

    }
}
