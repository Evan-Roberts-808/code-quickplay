using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrikeSystem : MonoBehaviour
{
    private int maxStrikesAllowed = 3;
    private int currentStrikes = 0;
    SharedGameLogic sharedGameLogic;

    // Start is called before the first frame update
    void Start()
    {
        sharedGameLogic = FindObjectOfType<SharedGameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sharedGameLogic.GetMinigameInProgress() && !sharedGameLogic.GetSucceeded())
        {
            OnMinigameFailed();
        }
    }

    private void OnMinigameFailed()
    {
        currentStrikes++;
        if (currentStrikes == maxStrikesAllowed)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnBossFailed()
    {
        currentStrikes++;
        if (currentStrikes == maxStrikesAllowed)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ResetStrikes()
    {
        currentStrikes = 0;
    }

}