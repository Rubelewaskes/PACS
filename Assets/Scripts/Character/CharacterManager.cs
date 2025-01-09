using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Мужские имена")]
    public List<string> maleNames; // = new List<string> { "Михаил", "Пётр", "Иван", "Максим", "Артем", "Лев", "Марк", "Матвей", "Владимир", "Кирилл"};
    [Header("Женские имена")]
    public List<string> femaleNames; // = new List<string> { "Ксения", "Ирина", "Анна", "Мария", "Анастасия", "Виктория", "Евгения"};
    public CharacterInformation[] characters;

    void Start()
    {
        foreach (CharacterInformation character in characters)
        {
            if (character.gender == Gender.Male && maleNames.Count > 0) // Проверка пола и наличия имён
            {
                AssignName(character, maleNames); // Назначаем имя из мужского списка
            }
            else if (character.gender == Gender.Female && femaleNames.Count > 0) // Для женского пола
            {
                AssignName(character, femaleNames); // Назначаем имя из женского списка
            }
            else
            {
                character.characterName = "Безымянный"; // Имя по умолчанию, если подходящих имён нет
            }
        }
    }

    private void AssignName(CharacterInformation character, List<string> nameList)
    {
        int randomIndex = Random.Range(0, nameList.Count);
        string randomName = nameList[randomIndex];
        nameList.RemoveAt(randomIndex); // Удаляем имя из списка, чтобы оно не повторялось
        character.characterName = randomName; // Присваиваем имя персонажу
    }
}
