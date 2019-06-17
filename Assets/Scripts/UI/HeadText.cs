using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadText : MonoBehaviour
{
    public Army armyScript;
    TextMesh textmsh;

    
    // Start is called before the first frame update
    void Start()
    {

        textmsh = GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {

        textmsh.text = $"{armyScript.nTroops}";


    }
}
