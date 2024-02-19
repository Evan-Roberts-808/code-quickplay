using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedGameLogic : MonoBehaviour
{
    private bool isPlaying;
    private bool succeeded;

    // Getters
    public bool GetIsPlaying()
    {
        return isPlaying;
    }

    public bool GetSucceeded()
    {
        return succeeded;
    }

    public void CompletedMinigame()
    {
        isPlaying = false;
        succeeded = true;
    }

    public void FailedMinigame()
    {
        isPlaying = false;
        succeeded = false;
    }
}
