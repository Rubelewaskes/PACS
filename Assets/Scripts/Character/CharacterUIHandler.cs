using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUIHandler : MonoBehaviour
{
    public Color selectedColor = new Color(0.8f, 0.8f, 1f); // Цвет выделения
    private Color originalColor; // Исходный цвет
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;

    public GameObject infoPanel; // Ссылка на панель меню
    public TextMeshProUGUI infoText;

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

    public bool IsPanelActive(){
        return infoPanel.activeSelf;
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
        if (infoPanel != null )
        {
            infoPanel.SetActive(true); // Показываем меню
        }
    }

    public void HideInfoMenu()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false); // Скрываем меню
        }
    }

    public void SetText()
    {
        if (characterInformation != null){
            string info = $"ID: {characterInformation.characterID}\n" + 
                         $"Имя: {characterInformation.characterName}\n" + 
                         $"Возраст: {characterInformation.age}\n" + 
                         $"Должность: {characterInformation.position}\n" + 
                         $"Доступные комнаты: {string.Join(", ", characterInformation.accessibleRooms)}";

            infoText.text = info;
        }
    }
}
