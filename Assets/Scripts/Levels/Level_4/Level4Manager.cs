using UnityEngine;
using UnityEngine.UI;

public class Level4Manager : LevelManager
{
    public PauseManager Pause;
    private bool isPaused;

    public override void Start()
    {

    }

    void Update()
    {
        if (PauseManager.IsPaused)
        {
            isPaused = true;
        }
        else if (isPaused)
        {
            isPaused = false;
        }
    }
}
