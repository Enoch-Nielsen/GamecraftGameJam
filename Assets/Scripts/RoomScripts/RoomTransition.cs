using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] GameObject playerSpawnSpace = null;
    [SerializeField] float transiftionTime = 2;

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

        player.gameObject.SetActive(false);

        StartCoroutine(RoomChangeTime(player));

    }

    private IEnumerator RoomChangeTime(PlayerController player)
    {
        yield return new WaitForSeconds(transiftionTime);

        player.gameObject.SetActive(true);
        player.transform.position = playerSpawnSpace.transform.position;
    }
}
