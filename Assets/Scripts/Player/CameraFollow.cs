using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [Range(0, 1)] [SerializeField] private float distance;

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, distance * Time.deltaTime);
    }
}
