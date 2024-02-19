using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerImage;
    [SerializeField] float timeLimit = 8f;

    public float fillFraction;
    public bool finishedMinigame = false;
    float timerValue;

    private void Start()
    {
        timerValue = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0f;
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (!finishedMinigame)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeLimit;

                timerImage.fillAmount = fillFraction;
            }
        }
        else
        {
            finishedMinigame = true;
            // Add logic later to switch minigames once completed or timer runs out
        }
        Debug.Log(timerValue);
    }
}