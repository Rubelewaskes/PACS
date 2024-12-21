using UnityEngine;

public enum Gender
{
    Male,
    Female
}

public class CharacterInformation : MonoBehaviour
{
    [Header("ID")]
    public int characterID;
    [Header("Имя")]
    public string characterName;
    [Header("Возраст")]
    public int age;
    [Header("Должность")]
    public string position;
    [Header("Пол")]
    public Gender gender;

    [Header("Доступы")]
    public string[] accessibleRooms;
}