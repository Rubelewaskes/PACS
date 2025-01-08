using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public PauseManager manager;
    void Start()
    {
        manager.PauseGame();
    }
}