using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static float currentTime = 0f;
    float startingTime = 360f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime<= 0)
        {
            currentTime = 0;
        }
    }

    public static void setCurrentTimer(float ct)
    {
        currentTime = ct;
    }

    public static float getCurrentTimer()
    {
        return currentTime;
    }
}
