using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Standart defensive formation, helps army hold their ground and moves slower.
/// </summary>
public class FBrace : Formation
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        thisFormation = EnumArmyStates.Brace;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerControl)
        {

            if(Input.GetAxis("Brace") > 0)
            {
                ActivateFormation();
                Debug.Log("Brace");
            }

        }

    }
}
