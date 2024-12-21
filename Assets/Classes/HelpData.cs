[System.Serializable]
public class HelpItem
{
    public string title;   // Заголовок пункта
    public string content; // Содержимое пункта
}

[System.Serializable]
public class HelpData
{
    public HelpItem[] items; // Массив пунктов справочника
}