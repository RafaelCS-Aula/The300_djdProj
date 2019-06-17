using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the camera relative to the player
/// </summary>
public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float lookAhead;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;

    public Transform target;

    private void Start()
    {
    }


    void LateUpdate()
    {
        if (target == null)
            return;

        transform.position = new Vector3(Mathf.Clamp((target.position.x + lookAhead), xMin, xMax), Mathf.Clamp((target.position.y - lookAhead), yMin, yMax), transform.position.z);

    }
}