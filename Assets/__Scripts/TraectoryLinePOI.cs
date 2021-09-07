using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraectoryLinePOI : MonoBehaviour
{
    [Header("Set in Inspector")]
    private LineRenderer line;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void ShowTraectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[30];
        line.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time*time/2f;

            if (points[i].y < -2)
            {
                line.positionCount = i + 1;
                break;
            }
        }

        line.SetPositions(points);
    }
}
