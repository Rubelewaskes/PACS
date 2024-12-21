using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level1Manager : LevelManager
{
    // Панели подсказок
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint4;

    private bool wasHint1;
    private bool wasHint2;
    private bool wasHint3;
    private bool wasHint4;

    public CharacterSelection CharSel;

    public PauseManager Pause;

    // Панель информации о персонаже
    public GameObject helpMenu;

    private bool isPaused;

    public override void Start()
    {
        // Изначально скрываем все подсказки
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint4.SetActive(false);

        wasHint1 = false;
        wasHint2 = false;
        wasHint3 = false;
        wasHint4 = false;

        // Начинаем показ подсказок
        StartCoroutine(ShowHints());
    }

    // Корутина для показа подсказок
    private IEnumerator ShowHints()
    {
        ShowHint1();
        yield return new WaitForSecondsRealtime(3f); // Используем WaitForSecondsRealtime, чтобы игнорировать паузу
        ShowHint2();
        yield return new WaitForSecondsRealtime(1f); // Пауза не влияет на таймеры
    }

    private void ShowHint1()
    {
        if (!wasHint1)
        {
            hint1.SetActive(true);
        }
    }

    private void ShowHint2()
    {
        if (!wasHint2)
        {
            hint2.SetActive(true);
        }
    }

    public void ShowCharacterInfo()
    {
        if (!wasHint3)
        {
            // Закрываем подсказки
            hint1.SetActive(false);
            hint2.SetActive(false);
            wasHint1 = true;
            wasHint2 = true;
            

            // Делаем активной третью подсказку
            hint3.SetActive(true);

            // После 5 секунд скрываем информацию
            StartCoroutine(CloseHint3());
        }
    }

    private IEnumerator CloseHint3()
    {
        yield return new WaitForSecondsRealtime(5f);
        CharSel.TriggerOnMouseDown();
        hint3.SetActive(false);
        wasHint3 = true;
        OpenHelpMenu();
    }

    private void OpenHelpMenu()
    {
        helpMenu.SetActive(true);
    }

    public void ShowHint4()
    {
        if (!wasHint4)
        {
            hint4.SetActive(true);
        }
    }

    public void HideHint4()
    {
        if (!wasHint4)
        {
            hint4.SetActive(false);
            wasHint4 = true;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level_2");
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
