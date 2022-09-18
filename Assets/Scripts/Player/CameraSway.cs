using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    [SerializeField] private float swaySpeed = 1;
    [SerializeField] private float currentSwaySpeed = 1;
    [SerializeField] private float swayBounds;

    [SerializeField] private Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = gameObject.transform.localRotation;
        cameraTransform.Rotate(Vector3.forward * Time.deltaTime * currentSwaySpeed);
        
        if (currentRotation.z * 57.29 < -swayBounds)
        {
            currentSwaySpeed = swaySpeed;
        }
        else if (currentRotation.z * 57.29> swayBounds)
        {
            currentSwaySpeed = -swaySpeed;
        }
        
        Debug.Log(currentRotation.z * 57.29);
    }
}
