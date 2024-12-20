using UnityEngine;
using UnityEngine.Events; 

public class CharacterSelection : MonoBehaviour
{
    private bool isMenuOpen = false; // Статус меню

    public UnityEvent chooseCharacter;
    public UnityEvent TriggerMouseDown;

    public void OnMouseDown()
    {
        isMenuOpen = !isMenuOpen; // Переключаем состояние меню

        CharacterUIHandler characterUIHandler = GetComponent<CharacterUIHandler>();
        if (characterUIHandler != null)
        {
            if (isMenuOpen)
            {
                //characterUIHandler.HighlightCharacter(); // Выделяем персонажа
                characterUIHandler.ShowInfoMenu(); // Показываем меню
                chooseCharacter?.Invoke();
            }
            else
            {
                //characterUIHandler.UnhighlightCharacter(); // Убираем выделение
                characterUIHandler.HideInfoMenu(); // Скрываем меню
            }
        }
    }

    public void TriggerOnMouseDown()
    {
        TriggerMouseDown?.Invoke();
    }
}
