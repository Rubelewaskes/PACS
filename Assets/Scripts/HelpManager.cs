using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class HelpManager : MonoBehaviour
{
    public TMP_Text infoText;      // Поле для отображения информации
    public Button[] menuButtons;   // Массив кнопок меню

    private HelpData helpData; // Данные из JSON

    void Start()
    {
        LoadDataFromJson();

        // Привязываем события нажатия кнопок
        for (int i = 0; i < menuButtons.Length; i++)
        {
            int index = i; // Локальная переменная для замыкания
            menuButtons[i].onClick.AddListener(() => ShowInfo(index));
            menuButtons[i].GetComponentInChildren<TMP_Text>().text = helpData.items[i].title; // Заголовки на кнопках
        }

        // Показываем информацию по умолчанию
        ShowInfo(0);
    }

    void LoadDataFromJson()
    {
        // Путь к файлу JSON на уровень выше
        string path = Path.Combine(Application.dataPath, "helpInfo.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            helpData = JsonUtility.FromJson<HelpData>(json);
        }
        else
        {
            Debug.LogError("JSON файл не найден по пути: " + path);
        }
    }

    void ShowInfo(int index)
    {
        // Обновляем текст в правой части
        if (index >= 0 && index < helpData.items.Length)
        {
            infoText.text = helpData.items[index].content;
        }
        else
        {
            infoText.text = "Данные отсутствуют.";
        }
    }
}