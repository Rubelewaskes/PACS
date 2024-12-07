using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Color selectedColor = new Color(0.8f, 0.8f, 1f); // Цвет выделения
    private Color originalColor; // Исходный цвет
    private SpriteRenderer spriteRenderer;

    public CharacterData characterData; // Данные персонажа

    public GameObject infoPanel; // Ссылка на панель меню
    public Text nameText; // Поле для имени
    public Text ageText; // Поле для возраста
    public Text positionText; // Поле для должности

    private bool isMenuOpen = false; // Статус меню

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Сохраняем исходный цвет
        }

        if (infoPanel != null)
        {
            infoPanel.SetActive(false); // Скрываем панель при старте
        }
    }

    void OnMouseDown()
    {
        isMenuOpen = !isMenuOpen; // Переключаем состояние меню

        if (isMenuOpen)
        {
            HighlightCharacter(); // Выделяем персонажа
            ShowInfoMenu(); // Показываем меню
        }
        else
        {
            UnhighlightCharacter(); // Убираем выделение
            HideInfoMenu(); // Скрываем меню
        }
    }

    void HighlightCharacter()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = selectedColor; // Меняем цвет
        }
    }

    void UnhighlightCharacter()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor; // Возвращаем исходный цвет
        }
    }

    void ShowInfoMenu()
    {
        if (infoPanel != null && characterData != null)
        {
            infoPanel.SetActive(true); // Показываем меню

            nameText.text = $"Имя: {characterData.name}";
            ageText.text = $"Возраст: {characterData.age}";
            positionText.text = $"Должность: {characterData.position}";

        }
    }

    void HideInfoMenu()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false); // Скрываем меню
        }
    }
}
