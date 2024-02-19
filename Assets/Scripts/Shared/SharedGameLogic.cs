using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class SharedGameLogic : MonoBehaviour
{
    private bool minigameInProgress;
    private bool succeeded;

    // Getters
    public bool GetMinigameInProgress()
    {
        return minigameInProgress;
    }

    public bool GetSucceeded()
    {
        return succeeded;
    }

    public void CompletedMinigame()
    {
        minigameInProgress = false;
        succeeded = true;
    }

    public void FailedMinigame()
    {
        minigameInProgress = false;
        succeeded = false;
    }

    public void ResetValues(){
        minigameInProgress = true;
        succeeded = false;
    }
}
