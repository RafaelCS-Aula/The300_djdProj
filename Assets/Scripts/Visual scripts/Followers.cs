using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Shows the troops behind the leader, and can serve as health display.
/// </summary>
public class Followers : MonoBehaviour
{
    [HideInInspector] public Army aScript;
    
    
    [SerializeField] GameObject soldierPrefab;

    [SerializeField]
    int amountToShow;
    
    [SerializeField]
    float trailLength;

    GameObject currObj;

    //===============================================
    Vector3[] followPositions;
    float followerSpacing;

    // Start is called before the first frame update
    private void Start()
    {
        aScript = GetComponent<Army>();
        followPositions = new Vector3[aScript.nTroops];

        UpdatePositions(aScript.nTroops);
        UpdateFollowers(aScript.nTroops);
    }

    public void UpdatePositions(int troops)
    {
        if (followPositions == null)
            followPositions = new Vector3[troops];

        for (int i = 0; i < followPositions.Length; i++)
        {
            followPositions[i] = new Vector3(0, 0, 0);
            followPositions[i].x = trailLength / troops * (i + 1);
        }
    }

    // Update is called once per frame
    public void UpdateFollowers(int troops)
    {
        for (int i = 0; i < amountToShow && i < troops; i++)
        {
            float dir = Mathf.Sign(aScript.speed);
            float spawnX = (transform.position.x - followPositions[i].x) * dir;
            Vector3 v = new Vector3(spawnX, transform.position.y - 0.6f, transform.position.z - 8);
            currObj = Instantiate(soldierPrefab,v, Quaternion.identity);
            
            // Add this as child to the army object
            currObj.transform.parent = transform;

            // this needs to be here or the sprites for the player followers get all messed up I dont even know
            currObj.transform.localScale = new Vector3(0.125f,0.125f,1);
        }
    }
}
