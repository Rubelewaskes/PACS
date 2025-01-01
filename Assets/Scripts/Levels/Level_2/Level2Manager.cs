using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level2Manager : LevelManager
{
    public Button start;
    public Button pause;

    private bool[] selected = {false, false, false};

    public PauseManager Pause;
    public HelpManager Help;

    private bool isPaused;

    public override void Start()
    {

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
        yield return new WaitForSecondsRealtime(2f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHintByID(1);
        yield return new WaitForSecondsRealtime(0.5f); // Пауза не влияет на таймеры
        ShowHintByID(2);
        yield return new WaitForSecondsRealtime(0.5f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHintByID(3);
        yield return new WaitForSecondsRealtime(3f);
        CloseHints(0, 4);
        yield return new WaitForSecondsRealtime(1f);
        ShowHintByID(4);
        yield return new WaitForSecondsRealtime(1f);
        ShowHintByID(5);
    }



    public void SelectedAccounter()
    {
        selected[0] = true;
        StartCoroutine(tryShowHints7_8());
    }

    public void SelectedProgrammer()
    {
        selected[1] = true;
        StartCoroutine(tryShowHints7_8());
    }

    public void SelectedDirector()
    {
        selected[2] = true;
        StartCoroutine(tryShowHints7_8());
    }

    private IEnumerator tryShowHints7_8()
    {
        if (selected[0] && selected[1] && selected[2] && !wasHints[4] && !wasHints[5])
        {
            CloseHints(4, 6);

            ShowHintByID(6);
            yield return new WaitForSecondsRealtime(2f);
            ShowHintByID(7);
        }
    }

    public void OpenedHelpMenu()
    {
        if (!wasHints[6] && !wasHints[7])
        {
            CloseHints(6, 8);
            start.interactable = true;
            pause.interactable = true;
            wasHints[6] = true;
            wasHints[7] = true;
            Help.ShowInfo(7);
        }
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level_3");
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
