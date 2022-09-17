using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] PlayerController player = null;
    [SerializeField] Material nonInteractableMaterial = null;
    [SerializeField] Material interactableMaterial = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<PlayerController>(out player))
        {
            return;
        }

        this.GetComponent<Renderer>().material = interactableMaterial;     

        player.canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<PlayerController>(out player))
        {
            return;
        }

        this.GetComponent<Renderer>().material = nonInteractableMaterial;

        player.canInteract = false;
        player = null;
    }
}
