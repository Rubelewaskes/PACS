using UnityEngine;

public class ToggleWindow : MonoBehaviour
{
    public GameObject window; // Ссылка на окно, которое будет скрываться/показываться

    private bool isWindowVisible = false; // Статус видимости окна

    public void ToggleVisibility()
    {
        if (window != null)
        {
            isWindowVisible = !isWindowVisible; // Меняем статус видимости
            window.SetActive(isWindowVisible); // Включаем/выключаем объект окна
        }
    }
}
