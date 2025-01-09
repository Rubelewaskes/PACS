using UnityEngine;

public class ToggleWindow : MonoBehaviour
{
    public GameObject window; // Ссылка на окно, которое будет скрываться/показываться

    public void ToggleVisibility()
    {
        if (window != null)
        {
            bool currentVisibility = window.activeSelf; // Получаем текущий статус видимости
            window.SetActive(!currentVisibility);      // Меняем на противоположный
        }
    }
}