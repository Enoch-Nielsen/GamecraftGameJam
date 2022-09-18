using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] GameObject playerSpawnSpace = null;
    [SerializeField] float transitionTime = 2;
    [SerializeField] GameObject cameraObject = null;
    [SerializeField] GameObject nextCameraPlacement = null;
    [SerializeField] bool teleportPlayer = false;

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
        if (!other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            return;
        }
        /*if (teleportPlayer)
        {*/
            player.gameObject.SetActive(false);

            StartCoroutine(RoomChangeTime(player));
        /*}
        else
        {
            cameraObject.transform.position = nextCameraPlacement.transform.position;
            cameraObject.transform.rotation = nextCameraPlacement.transform.rotation;
        }*/



    }

    private IEnumerator RoomChangeTime(PlayerController player)
    {
        yield return new WaitForSeconds(transitionTime);

        player.gameObject.SetActive(true);
        player.transform.position = playerSpawnSpace.transform.position;
        cameraObject.transform.position = nextCameraPlacement.transform.position;
        cameraObject.transform.rotation = nextCameraPlacement.transform.rotation;
    }
}
