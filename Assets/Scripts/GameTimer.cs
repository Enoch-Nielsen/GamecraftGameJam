using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] PlayerController player = null;
    [SerializeField] AudioSource deathSound = null;
    //[SerializeField] GameManager gameManager = null;
    [SerializeField] GameObject game = null;
    [SerializeField] GameObject gameOverScreen = null;
    [SerializeField] GameObject alarmAudio = null;
    private float waterLevel = 0;
    public TextMeshProUGUI timerText;
    public int timeMinute = 5;
    public int timeSecond = 0;
    public bool hasTimeLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        if (hasTimeLeft)
        {
            StartCoroutine(CountDown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTimeLeft)
        {
            deathSound.enabled = true;
            game.SetActive(false);
            gameOverScreen.SetActive(true);
            alarmAudio.SetActive(false);
        }
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        timeSecond--;
        waterLevel += 0.00001f;
        player.waterSpeed /= waterLevel + 1;
        if(timeSecond < 0)
        {
            if(!(timeMinute <= 0))
            {
                timeMinute--;
                timeSecond = 59;
            }

        }
        if(timeSecond < 10)
        {
            timerText.text = timeMinute + ":0" + timeSecond;
        }
        else
        {
            timerText.text = timeMinute + ":" + timeSecond;
        }
        if (timeMinute == 0 && timeSecond == 0)
        {
            hasTimeLeft = false;
            StopCoroutine(CountDown());            
        }
        if (hasTimeLeft)
        {
            StartCoroutine(CountDown());
        }

    }

    public void ResumeTimer()
    {
        timeSecond--;
        StartCoroutine(CountDownAgain());
    }

    private IEnumerator CountDownAgain()
    {
        timeSecond--;
        waterLevel += 0.00001f;
        player.waterSpeed /= waterLevel + 1;
        if (timeSecond < 0)
        {
            if (!(timeMinute <= 0))
            {
                timeMinute--;
                timeSecond = 59;
            }

        }
        if (timeSecond < 10)
        {
            timerText.text = timeMinute + ":0" + timeSecond;
        }
        else
        {
            timerText.text = timeMinute + ":" + timeSecond;
        }

        yield return new WaitForSeconds(0.00001f);

        StartCoroutine(CountDown());
        StopCoroutine(CountDownAgain());
    }
}
