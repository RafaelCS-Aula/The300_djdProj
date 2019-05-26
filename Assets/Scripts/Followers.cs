using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followers : MonoBehaviour
{

    /// <summary>
    /// Shows the troops behind the leader, and can serve as health display.
    /// </summary>
    Army aScript;

    

    [SerializeField]
    GameObject soldierPrefab;

    [SerializeField]
    int amountToShow;
    
    [SerializeField]
    float trailLength;

    GameObject currObj;

    // Start is called before the first frame update
    void Start()
    {
        aScript = GetComponent<Army>();

        UpdateFollowers(aScript.nTroops);
        
    }

    // Update is called once per frame
    void Update()
    {

        amountToShow = Mathf.Clamp(amountToShow, 0, aScript.nTroops);

    }

    public void UpdateFollowers(float nFollowers)
    {

        if(transform.childCount > 0) 
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i));
            }

        }

        for (int i = 0; i < amountToShow; i++)
        {
            currObj = Instantiate(soldierPrefab);
            currObj.transform.SetParent(this.transform);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (gameObject.tag == "Enemy")
            {

                transform.GetChild(i).transform.localPosition = new Vector3(32 * (i + 1), 0, 0);

            }

            if (gameObject.tag == "Player")
            {

                transform.GetChild(i).transform.localPosition = new Vector3(-32 * (i + 1), 0, 0);

            }
        }

    }
}
