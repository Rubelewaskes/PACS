using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level3Manager : LevelManager
{
    public Button start;
    public Button pause;

    public PauseManager Pause;
    public HelpManager Help;

    public GameObject ChooseMenu;

    private bool isPaused;

    // Кнопки управления в конце
    public Button restartLevelButton;
    public Button nextLevelButton;

    public override void Start()
    {
        Pause.PauseGame();

        for (int i = 0; i < hints.Length; i++)
        {
            wasHints = new bool[hints.Length];
            if (hints[i] != null)
            {
                hints[i].SetActive(false);
                wasHints[i] = false;   
            }
        }

        StartCoroutine(ShowHints());
    }

    // Корутина для показа подсказок
    private IEnumerator ShowHints()
    {
        ShowHintByID(0);
        yield return new WaitForSecondsRealtime(3f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHintByID(1);
        yield return new WaitForSecondsRealtime(3f); // Пауза не влияет на таймеры
        CloseHints(0, 2);
        ShowHintByID(2);
        yield return new WaitForSecondsRealtime(2f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHintByID(3);
        yield return new WaitForSecondsRealtime(2f);
        ShowHintByID(4);
        start.interactable = true;
        pause.interactable = true;
    }

    public void StartGame()
    {
        StartCoroutine(ShowHintsAfterStart());
    }
    
    private IEnumerator ShowHintsAfterStart()
    {
        CloseHints(2, 5);
        ShowHintByID(5);
        yield return new WaitForSecondsRealtime(1f);
        ShowHintByID(6);
        yield return new WaitForSecondsRealtime(3f);
        ShowHintByID(7);
    }

    public void OpenChooseMenu()
    {
        ChooseMenu.SetActive(true);
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
