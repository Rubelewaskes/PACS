using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public JournalController journalController; // Контроллер журнала
    public SpriteRenderer doorRenderer; // Спрайт двери

    // Цвет для активного состояния
    private Color openColor = new Color(121 / 255f, 221 / 255f, 126 / 255f);
    // Цвет для закрытого состояния
    private Color closedColor = new Color(212 / 255f, 86 / 255f, 85 / 255f);

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, если объект, вошедший в триггер, это персонаж
        if (other.CompareTag("Worker") || other.CompareTag("Imposter"))
        {
            // Изменяем цвет двери при открытии
            if (doorRenderer != null)
            {
                doorRenderer.color = openColor;
                // Проверяем, если объект, покидающий триггер, это персонаж
                if (other.CompareTag("Worker") || other.CompareTag("Imposter"))
                {

                    // Получаем компонент персонажа
                    CharacterInformation сharacterInformation = other.GetComponent<CharacterInformation>();
                    DoorInformation doorInformation = gameObject.GetComponent<DoorInformation>();

                    // Проверяем, если компонент найден
                    if (сharacterInformation != null)
                    {
                        // Формируем сообщение для журнала
                        string message = "";
                        if (сharacterInformation.gender == Gender.Male){
                            message = $"{сharacterInformation.characterName} прошёл дверь в {doorInformation.roomName}";
                        }
                        else if (сharacterInformation.gender == Gender.Female){
                            message = $"{сharacterInformation.characterName} прошла дверь в {doorInformation.roomName}";
                        }

                        // Добавляем запись в журнал
                        if (journalController != null)
                        {
                            journalController.AddEntry(message, other.gameObject);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Персонаж не имеет компонента CharacterInformation.");
                    }
                }
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        
        // Изменяем цвет двери при закрытии
        if (doorRenderer != null)
        {
            doorRenderer.color = closedColor;
        }
    }
}