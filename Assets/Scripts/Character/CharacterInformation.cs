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

    public void CopyFrom(CharacterInformation other)
    {
        if (other == null) return;

        this.characterID = other.characterID;
        this.characterName = other.characterName;
        this.age = other.age;
        this.position = other.position;
        this.gender = other.gender;
        this.accessibleRooms = other.accessibleRooms;
    }
}