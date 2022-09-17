using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject gameUI = null;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            gameUI.SetActive(false);
            player.GetComponent<PlayerController>().enabled = false;
            mainCamera.GetComponent<CameraSway>().enabled = false;
        }
    }

    public void OnResume()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    public void OnQuit()
    {
        SceneManager.LoadScene("EngineerTesting");
    }
}
