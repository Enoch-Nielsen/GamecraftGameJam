using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    [SerializeField] float swaySpeed = 1;
    [SerializeField] Transform cameraTransform = null;
    //[SerializeField] float swayHold = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Transform currentRotation = this.transform;
        cameraTransform.Rotate(Vector3.forward * Time.deltaTime * swaySpeed);
        
        if (currentRotation.transform.rotation.z < -0.5f)
        {
            swaySpeed *= -1;
        }
        else if (currentRotation.transform.rotation.z > 0.5f)
        {
            swaySpeed *= -1;
        }
    }

    private Transform GetTransform()
    {
        cameraTransform = this.gameObject.GetComponent<Transform>();
        Debug.Log(cameraTransform.rotation.z);
        return cameraTransform;
    }

}
