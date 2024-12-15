using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private bool isMenuOpen = false; // Статус меню
    public LevelManager levelManager;

    void OnMouseDown()
    {
        isMenuOpen = !isMenuOpen; // Переключаем состояние меню

        CharacterUIHandler characterUIHandler = GetComponent<CharacterUIHandler>();
        if (characterUIHandler != null)
        {
            if (isMenuOpen)
            {
                //characterUIHandler.HighlightCharacter(); // Выделяем персонажа
                characterUIHandler.ShowInfoMenu(); // Показываем меню
            }
            else
            {
                //characterUIHandler.UnhighlightCharacter(); // Убираем выделение
                characterUIHandler.HideInfoMenu(); // Скрываем меню
            }
        }
        if (levelManager != null)
        {
            levelManager.ShowCharacterInfo();
        }
    }
}
