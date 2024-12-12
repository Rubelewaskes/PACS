using UnityEngine;
using UnityEngine.UI;

public class CharacterUIHandler : MonoBehaviour
{
    public Color selectedColor = new Color(0.8f, 0.8f, 1f); // Цвет выделения
    private Color originalColor; // Исходный цвет
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;

    public GameObject infoPanel; // Ссылка на панель меню
    public Text nameText; // Поле для имени
    public Text ageText; // Поле для возраста
    public Text positionText; // Поле для должности

    public CharacterInformation characterInformation; // Данные персонажа

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
        if (spriteRenderer != null)
        {
            originalMaterial = spriteRenderer.material; // Сохраняем оригинальный материал
        }
    }

    public void HighlightCharacter()
    {
        if (spriteRenderer != null)
        {
            // Создаем новый материал, который накладывает цвет, а не изменяет сам спрайт
            Material highlightMaterial = new Material(originalMaterial)
            {
                color = selectedColor // Устанавливаем наложенный цвет
            };
            spriteRenderer.material = highlightMaterial; // Применяем материал с цветом
        }
    }

    public void UnhighlightCharacter()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.material = originalMaterial; // Восстанавливаем оригинальный материал
        }
    }

    public void ShowInfoMenu()
    {
        if (infoPanel != null && characterInformation != null)
        {
            infoPanel.SetActive(true); // Показываем меню

            nameText.text = $"Имя: {characterInformation.characterName}";
            ageText.text = $"Возраст: {characterInformation.age}";
            positionText.text = $"Должность: {characterInformation.position}";
        }
    }

    public void HideInfoMenu()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false); // Скрываем меню
        }
    }
}
