using UnityEngine;
using UnityEngine.UI;

public class Level4Manager : LevelManager
{
    public ButtonsFillScript fill;
    public GameObject ChooseMenu;
    public GameObject chooseMenuButton;
    public Button[] varButtons;
    public Button nextLevelButton;
    public PauseManager Pause;
    private bool isPaused;
    private bool chooseMenuOpened;
    public int rightButtonIndex;
    public int chooseTries = 0;
    public Color shadowGreen = new Color(0f, 1f, 0f, 0.5f);
    public Color shadowRed = new Color(1f, 0f, 0f, 0.5f);

    public override void Start()
    {
        chooseMenuOpened = false;

        chooseRightButton();
        fill.Filling(rightButtonIndex, varButtons);

        for (int i = 0; i < varButtons.Length; i++)
        {
            int buttonIndex = i;
            varButtons[i].onClick.AddListener(() => changeChooseButtonsColor(buttonIndex));
        }

        for (int i = 0; i < hints.Length; i++)
        {
            wasHints = new bool[hints.Length];
            if (hints[i] != null)
            {
                hints[i].SetActive(true);
                wasHints[i] = false;   
            }
        }

        Pause.PauseGame();
    }

    public void closeStartHint() {
        CloseHints(0, 1);
        chooseMenuButton.SetActive(true);
    }

    public void OpenChooseMenu()
    {
        if (!chooseMenuOpened) {
            ChooseMenu.SetActive(true);
            chooseMenuOpened = true;
        } else {
            ChooseMenu.SetActive(false);
            chooseMenuOpened = false;
        }
    }

    public void chooseRightButton() {
        rightButtonIndex = Random.Range(0, 3); // от 0 до 2 т.к. такие индексы у прогеров
    }

    public void changeChooseButtonsColor(int buttonIndex) {

        varButtons[buttonIndex].interactable = false;

        if (buttonIndex == rightButtonIndex) {
            var buttonColor = varButtons[buttonIndex].colors;
            buttonColor.disabledColor = Color.green;
            varButtons[buttonIndex].colors = buttonColor;

            endGame();

        } else if (buttonIndex != rightButtonIndex && chooseTries != 2) {
            var buttonColor = varButtons[buttonIndex].colors;
            buttonColor.disabledColor = shadowRed;
            varButtons[buttonIndex].colors = buttonColor;
            chooseTries += 1;

        } else if (buttonIndex != rightButtonIndex && chooseTries == 2) {
            var buttonColor = varButtons[buttonIndex].colors;
            buttonColor.disabledColor = shadowRed;
            varButtons[buttonIndex].colors = buttonColor;

            buttonColor = varButtons[rightButtonIndex].colors;
            buttonColor.disabledColor = shadowGreen;
            varButtons[rightButtonIndex].colors = buttonColor;

            endGame();
        }
    }

    public void endGame() {
        foreach (Button button in varButtons) {
                button.interactable = false;
            }
        nextLevelButton.interactable = true;
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
