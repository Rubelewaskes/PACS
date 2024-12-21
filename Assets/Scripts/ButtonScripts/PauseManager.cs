using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused { get; private set; } = false; // Статус паузы

    public GameObject pauseMenu; // Ссылка на панель паузы (если есть)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Кнопка для переключения паузы
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;

        // Останавливаем или продолжаем игру
        Time.timeScale = IsPaused ? 0f : 1f;

        // Отображаем или скрываем меню паузы
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(IsPaused);
        }
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }
}
