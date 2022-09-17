using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player edited Variables
    [SerializeField] private float speed = 5;

    //Player public Variables
    public bool canInteract = false;

    //Player Specific Variables

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalMovement);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalMovement);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!canInteract)
            {
                return;
            }
            OnInteract();
        }
    }

    private void OnInteract()
    {
        Debug.Log("Hamburger");
    }

}
