using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level2Manager : LevelManager
{
    // Панели подсказок
    public GameObject[] hints;
    public Button start;
    public Button pause;

    private bool[] wasHints;

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
        ShowHint1();
        yield return new WaitForSecondsRealtime(2f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHint2();
        yield return new WaitForSecondsRealtime(0.5f); // Пауза не влияет на таймеры
        ShowHint3();
        yield return new WaitForSecondsRealtime(0.5f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHint4();
        yield return new WaitForSecondsRealtime(3f);
        CloseHints(0, 4);
        yield return new WaitForSecondsRealtime(1f);
        ShowHint5();
        yield return new WaitForSecondsRealtime(1f);
        ShowHint6();
    }

    private void ShowHint1()
    {
        if (!wasHints[0])
        {
            hints[0].SetActive(true);
        }
    }

    private void ShowHint2()
    {
        if (!wasHints[1])
        {
            hints[1].SetActive(true);
        }
    }
    private void ShowHint3()
    {
        if (!wasHints[2])
        {
            hints[2].SetActive(true);
        }
    }

    private void ShowHint4()
    {
        if (!wasHints[3])
        {
            hints[3].SetActive(true);
        }
    }

    private void ShowHint5()
    {
        if (!wasHints[4])
        {
            hints[4].SetActive(true);
        }
    }

    private void ShowHint6()
    {
        if (!wasHints[5])
        {
            hints[5].SetActive(true);
        }
    }

    private void ShowHint7()
    {
        if (!wasHints[6])
        {
            hints[6].SetActive(true);
        }
    }
    private void ShowHint8()
    {
        if (!wasHints[7])
        {
            hints[7].SetActive(true);
        }
    }

    private void CloseHints(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            if (!wasHints[i]){
                wasHints[i] = true;
                hints[i].SetActive(false);
            }
        }
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

            ShowHint7();
            yield return new WaitForSecondsRealtime(2f);
            ShowHint8();
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
