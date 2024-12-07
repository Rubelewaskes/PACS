using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalController : MonoBehaviour
{
    public Transform journalContent; // Контейнер для отображения записей
    public GameObject journalEntryPrefab; // Префаб для записи журнала

    private List<JournalEntry> journalEntries = new List<JournalEntry>(); // Хранилище записей

    public void AddEntry(string message, GameObject character)
    {
        // Создаем новую запись
        JournalEntry newEntry = new JournalEntry(message, character, Time.time);
        journalEntries.Add(newEntry);

        // Добавляем запись на UI
        GameObject entryObject = Instantiate(journalEntryPrefab, journalContent);
        Button entryButton = entryObject.GetComponent<Button>();
        Text entryText = entryObject.GetComponentInChildren<Text>();

        if (entryText != null)
        {
            entryText.text = message; // Устанавливаем текст записи
        }

        // Подготовка кликов
        entryButton.onClick.AddListener(() =>
        {
            SelectCharacter(newEntry.character); // Выделяем персонажа
            JumpToTime(newEntry.timestamp); // Перематываем время (пока не реализовано)
        });
    }

    private void SelectCharacter(GameObject character)
    {
        if (character != null)
        {
            Debug.Log($"Выделен персонаж: {character.name}");
            // Здесь будет логика выделения персонажа
        }
    }

    private void JumpToTime(float timestamp)
    {
        Debug.Log($"Перемотка времени на момент: {timestamp}");
        // Здесь будет логика перемотки времени
    }
}