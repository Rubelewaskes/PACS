using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Color selectedColor = new Color(0.8f, 0.8f, 1f); // Цвет выделения
    private Color originalColor; // Исходный цвет
    private SpriteRenderer spriteRenderer; // Рендер персонажа

    public string characterName; // Имя персонажа
    public string characterInfo; // Краткая информация

    private bool isSelected = false; // Статус выделения

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Сохраняем оригинальный цвет
        }
    }

    void OnMouseDown()
    {
        isSelected = !isSelected; // Переключаем состояние выделения

        if (isSelected)
        {
            HighlightCharacter(); // Выделяем
            ShowInfo(); // Отображаем информацию
        }
        else
        {
            UnhighlightCharacter(); // Снимаем выделение
            HideInfo(); // Скрываем информацию
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

    void ShowInfo()
    {
        // Здесь логика отображения информации, например:
        Debug.Log($"Персонаж: {characterName}\nИнформация: {characterInfo}");
        // Можно создать UI элемент для отображения текста
    }

    void HideInfo()
    {
        // Здесь логика скрытия информации
        Debug.Log("Скрываем информацию о персонаже");
    }
}
