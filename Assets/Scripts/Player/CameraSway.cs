using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    [SerializeField] float swaySpeed = 1;
    [SerializeField] Transform cameraTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform currentRotation = GetTransform();
        if(currentRotation.transform.rotation.z < -0.05f)
        {
            swaySpeed *= -1;
        }
        else if(currentRotation.transform.rotation.z > 0.05f)
        {
            swaySpeed *= -1;
        }
            cameraTransform.Rotate(Vector3.forward * Time.deltaTime * swaySpeed);

    }

    private Transform GetTransform()
    {
        cameraTransform = this.gameObject.GetComponent<Transform>();
        Debug.Log(cameraTransform.rotation.z);
        return cameraTransform;
    }
}
