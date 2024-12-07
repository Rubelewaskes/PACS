using UnityEngine;

public class JournalEntry
{
    public string message; // Текст записи
    public GameObject character; // Ссылка на персонажа
    public float timestamp; // Время события

    public JournalEntry(string message, GameObject character, float timestamp)
    {
        this.message = message;
        this.character = character;
        this.timestamp = timestamp;
    }
}