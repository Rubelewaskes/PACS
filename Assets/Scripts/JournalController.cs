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
        });
    }

    private void SelectCharacter(GameObject character)
    {
        CharacterUIHandler characterUIHandler = character.GetComponent<CharacterUIHandler>();
        if (characterUIHandler != null)
        {
            //characterUIHandler.HighlightCharacter(); // Выделяем персонажа
            characterUIHandler.ShowInfoMenu(); // Показываем меню
        }
    }
}
