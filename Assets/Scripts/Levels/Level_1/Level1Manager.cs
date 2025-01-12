using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level1Manager : LevelManager
{
    public CharacterSelection CharSel;
    public GameObject ChooseMenu;
    public GameObject helpMenu;
    public GameObject CharacterInfoPanel;
    public PauseManager Pause;
    public Button start;
    public Button pause;
    public Button helpButton;
    // Панель информации о персонаже

    private bool isPaused;

    public override void Start()
    {
        // Изначально скрываем все подсказки
        for (int i = 0; i < hints.Length; i++)
        {
            wasHints = new bool[hints.Length];
            if (hints[i] != null)
            {
                hints[i].SetActive(false);
                wasHints[i] = false;   
            }
        }

        // Начинаем показ подсказок
        StartCoroutine(ShowHints());
    }

    // Корутина для показа подсказок
    private IEnumerator ShowHints()
    {
        ShowHintByID(0);
        yield return new WaitForSecondsRealtime(3f);
        ShowHintByID(1);
        yield return new WaitForSecondsRealtime(1f);
    }

    public void ShowCharacterInfo()
    {
        if (!wasHints[2])
        {
            // Закрываем подсказки
            CloseHints(0, 2);
            

            ShowHintByID(2);
            wasHints[2] = true;
            StartCoroutine(CloseHint3());
        }
    }

    private IEnumerator CloseHint3()
    {
        yield return new WaitForSecondsRealtime(4f);
        wasHints[2] = false;
        CloseHints(2, 3);
        OpenHelpMenu();
        CharacterInfoPanel.SetActive(false);
        helpButton.interactable = true;
    }

    private void OpenHelpMenu()
    {
        helpMenu.SetActive(true);
    }

    public void ShowHint4()
    {
        start.interactable = true;
        pause.interactable = true;
        ShowHintByID(3);
    }

    public void HideHint4()
    {
        CloseHints(3, 4);
    }

    public void OpenChooseMenu()
    {
        ChooseMenu.SetActive(true);
    }


    void Update()
    {
        // Проверка состояния паузы
        if (PauseManager.IsPaused)
        {
            // Если игра на паузе, сохраняем состояние
            isPaused = true;
        }
        else if (isPaused)
        {
            // Если только что сняли паузу, можно продолжить действия
            isPaused = false;
        }
    }
}
