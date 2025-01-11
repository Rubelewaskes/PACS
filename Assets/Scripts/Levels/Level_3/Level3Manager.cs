using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level3Manager : LevelManager
{
    public Button start;
    public Button pause;

    private bool[] selected = {false, false, false};

    public PauseManager Pause;
    public HelpManager Help;

    public GameObject ChooseMenu;

    private bool isPaused;

    // Кнопки выбора в конце
    public Button var1Button;
    public Button var2Button;
    public Button var3Button;

    // Кнопки управления в конце
    public Button restartLevelButton;
    public Button nextLevelButton;

    public override void Start()
    {
        Pause.PauseGame();

        restartLevelButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);

        var1Button.onClick.AddListener(() => { OnChoiceMade(var1Button); changeChooseButtonsColor(var1Button);}); // еба приколько так методы вызывать но я не уверен, что оно ваще надо
        var2Button.onClick.AddListener(() => { OnChoiceMade(var2Button); changeChooseButtonsColor(var2Button);});
        var3Button.onClick.AddListener(() => { OnChoiceMade(var3Button); changeChooseButtonsColor(var3Button);});

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

    // Метод для обработки выбора
    // тут чтобы кнопочки рестарта и некста появлялись
    public void OnChoiceMade(Button selectedButton)
    {
        // Делаем кнопки выбора неактивными
        var1Button.interactable = false;
        var2Button.interactable = false;
        var3Button.interactable = false;

        // Показываем кнопки управления
        restartLevelButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
    }

    public void changeChooseButtonsColor(Button selectedButton) { // эта ебола цвета меняет, как будто можно сделать компактнее, но мне похуй уже было
        Color shadowGreen = new Color(0f, 1f, 0f, 0.5f);
        Color shadowRed = new Color(1f, 0f, 0f, 0.5f);
        if (selectedButton == var1Button) {
            var var1ButtonColor = var1Button.colors;
            var1ButtonColor.disabledColor = Color.green;
            var1Button.colors = var1ButtonColor;

            var var2ButtonColor = var2Button.colors;
            var2ButtonColor.disabledColor = shadowRed;
            var2Button.colors = var2ButtonColor;

            var var3ButtonColor = var3Button.colors;
            var3ButtonColor.disabledColor = shadowRed;
            var3Button.colors = var3ButtonColor;
        }

        else if (selectedButton == var2Button) {
            var var1ButtonColor = var1Button.colors;
            var1ButtonColor.disabledColor = shadowGreen;
            var1Button.colors = var1ButtonColor;

            var var2ButtonColor = var2Button.colors;
            var2ButtonColor.disabledColor = Color.red;
            var2Button.colors = var2ButtonColor;

            var var3ButtonColor = var3Button.colors;
            var3ButtonColor.disabledColor = shadowRed;
            var3Button.colors = var3ButtonColor;
        }

        else if (selectedButton == var3Button) {
            var var1ButtonColor = var1Button.colors;
            var1ButtonColor.disabledColor = shadowGreen;
            var1Button.colors = var1ButtonColor;

            var var2ButtonColor = var2Button.colors;
            var2ButtonColor.disabledColor = shadowRed;
            var2Button.colors = var2ButtonColor;

            var var3ButtonColor = var3Button.colors;
            var3ButtonColor.disabledColor = Color.red;
            var3Button.colors = var3ButtonColor;
        }
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
        // OpenChooseMenu(); // тут я пытался вызвать его после отработки скрипта с хождением по комнате, но не получилось
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
