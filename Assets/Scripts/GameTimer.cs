using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
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

    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        timeSecond--;
        if(timeSecond < 0)
        {
            if(!(timeMinute <= 0))
            {
                timeMinute--;
                timeSecond = 59;
            }

        }

        timerText.text = timeMinute + ":" + timeSecond;
        if(timeMinute == 0 && timeSecond == 0)
        {
            hasTimeLeft = false;
            StopCoroutine(CountDown());            
        }
        if (hasTimeLeft)
        {
            StartCoroutine(CountDown());
        }

    }
}
