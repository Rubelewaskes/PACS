using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    public JournalController journalController;
    public GameObject chooseMenu;
    public ButtonsFillScript fill;
    private int countExited = 0;

    void OnTriggerEnter2D(Collider2D other)
    {

        // Проверяем, если объект, вошедший в триггер, это персонаж
        if (other.CompareTag("Worker") || other.CompareTag("Imposter"))
        {
            CharacterInformation сharacterInformation = other.GetComponent<CharacterInformation>();
            // Проверяем, если компонент найден
            if (сharacterInformation != null)
            {
                // Формируем сообщение для журнала
                string message = "";
                if (сharacterInformation.gender == Gender.Male){
                    message = $"{сharacterInformation.characterName} вышел из здания.";
                }
                else if (сharacterInformation.gender == Gender.Female){
                    message = $"{сharacterInformation.characterName} вышла из здания.";
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

            other.gameObject.SetActive(false);

            countExited++;
            if (countExited == 10)
            {
                chooseMenu.SetActive(true);
            }
        }
    }
}
