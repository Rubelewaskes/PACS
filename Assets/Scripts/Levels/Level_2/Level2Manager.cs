using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class Level2Manager : LevelManager
{
    public Button helpButton;
    public bool helpMenuOpened;
    private bool[] selected = {false, false, false};
    public PauseManager Pause;
    public HelpManager Help;
    public GameObject infoPanel;
    public GameObject ChooseMenu;

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
        yield return new WaitForSecondsRealtime(2f);
        ShowHintByID(1);
        yield return new WaitForSecondsRealtime(1f);
        ShowHintByID(2);
        yield return new WaitForSecondsRealtime(1f);
        ShowHintByID(3);
        yield return new WaitForSecondsRealtime(3f);
        CloseHints(0, 4);
        yield return new WaitForSecondsRealtime(0.5f);
        ShowHintByID(4);
        yield return new WaitForSecondsRealtime(3f);
        ShowHintByID(5);
    }

    public void SelectedPeople(int selectedCharachter)
    {
        selected[selectedCharachter] = true;
        if (selected.All(b => b) && selected.Length == 3) {
            StartCoroutine(tryShowHints7_8());
        }
    }

    private IEnumerator tryShowHints7_8()
    {
        if (!wasHints[4] && !wasHints[5])
        {
            helpButton.interactable = true;
            yield return new WaitForSecondsRealtime(3f);
            infoPanel.SetActive(false);
            CloseHints(4, 6);

            ShowHintByID(6);
            yield return new WaitForSecondsRealtime(3f);
            ShowHintByID(7);
            yield return new WaitForSecondsRealtime(3f);
        }
    }

    public void OpenedHelpMenu()
    {
        if (!wasHints[6] && !wasHints[7])
        {
            CloseHints(6, 8);
        }
    }
    public void HelpMenuOpenedToggle() 
    {
        helpMenuOpened = !helpMenuOpened;
    }

    public void OpenChooseMenu()
    {
        ChooseMenu.SetActive(!helpMenuOpened);
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
