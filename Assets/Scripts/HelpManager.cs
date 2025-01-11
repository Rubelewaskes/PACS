using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class HelpManager : MonoBehaviour
{
    public TMP_Text infoText;      // Поле для отображения информации
    public Button[] menuButtons;   // Массив кнопок меню

    public HelpData helpData; // Данные из JSON

    void Start()
    {
        LoadDataFromJson();

        // Привязываем события нажатия кнопок
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].onClick.AddListener(() => ShowInfo(i));
            menuButtons[i].GetComponentInChildren<TMP_Text>().text = helpData.items[i].title; // Заголовки на кнопках
        }

        // Показываем информацию по умолчанию
        ShowInfo(1);
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

    public void ShowInfo(int index)
    {
        // Обновляем текст в правой части
        if (index >= 0 && index < helpData.items.Length)
        {
            string content = helpData.items[index].content;

            content = content.Replace("\n", "<br>");
            content = $"<b><size=30>{helpData.items[index].title}</size></b><br><br>{content}";

            infoText.text = content;
        }
        else
        {
            infoText.text = "Данные отсутствуют.";
        }
    }
}