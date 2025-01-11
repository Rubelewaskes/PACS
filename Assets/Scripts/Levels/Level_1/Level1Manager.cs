using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level1Manager : LevelManager
{
    public CharacterSelection CharSel;
    public GameObject ChooseMenu;
    public PauseManager Pause;
    public Button start;
    public Button pause;

    private bool helpMenuOpened = false;
    // Панель информации о персонаже
    public GameObject helpMenu;
    public HelpManager Help;

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
        yield return new WaitForSecondsRealtime(3f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHintByID(1);
        yield return new WaitForSecondsRealtime(1f); // Пауза не влияет на таймеры
    }

    public void ShowCharacterInfo()
    {
        if (!wasHints[2])
        {
            // Закрываем подсказки
            CloseHints(0, 2);
            

            // Делаем активной третью подсказку
            ShowHintByID(2);
            wasHints[2] = true; // Костыль, чтобы не выскакивал справочник несколько раз
            // После 5 секунд скрываем информацию
            StartCoroutine(CloseHint3());
        }
    }

    private IEnumerator CloseHint3()
    {
        yield return new WaitForSecondsRealtime(4f);
        wasHints[2] = false;
        CloseHints(2, 3);
        OpenHelpMenu();
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
        if (!helpMenuOpened) {
            ChooseMenu.SetActive(true);
        } else {
            ChooseMenu.SetActive(false);
        }
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
