using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [Range(0, 1)] [SerializeField] private float distance;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, playerTransform.position.y + 3.8F, playerTransform.position.z);
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, playerTransform.position.y + 3.8F, playerTransform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, distance * Time.deltaTime);
    }
}
