using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkAnimation : MonoBehaviour
{
    [Header("Set in Inspector")]
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float time = 0;

    private void Start()
    {
        startPosition = transform.position;
        startPosition.y = transform.position.y - 50;
        targetPosition = transform.position + Vector3.up;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPosition, targetPosition, time/3);
        time += Time.deltaTime;
    }
}
