using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;

    public void Awake()
    {
        camZ = this.transform.position.z;
    }

    public void FixedUpdate()
    {
        if (POI == null) return;

        Vector3 destination = POI.transform.position;
        //destination.x = Mathf.Max(minXY.x, destination.x - 14);
        //destination.y = Mathf.Max(minXY.y, destination.y -9);
        destination.x = destination.x -15;
        destination.y = destination.y + 10;
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
    }
}
