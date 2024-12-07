using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name; // Имя персонажа
    public int age; // Возраст
    public string position; // Должность
    public string[] accessed_rooms; // Доступ к комнатам

    public override string ToString()
    {
        return $"Имя: {name}\nВозраст: {age}\nДолжность: {position}";
    }

    // Метод для возврата всей информации в виде словаря
    public Dictionary<string, object> getAllInfo()
    {
        return new Dictionary<string, object>()
        {
            { "name", name },
            { "age", age },
            { "position", position },
            { "accessed_rooms", accessed_rooms }
        };
    }

    public string getName()
    {
        return name;
    }

    public int getAge() // Исправлено: возвращаемый тип должен быть int
    {
        return age;
    }

    public string getPosition()
    {
        return position;
    }

    public string[] getAccessedRooms()
    {
        return accessed_rooms;
    }
}
