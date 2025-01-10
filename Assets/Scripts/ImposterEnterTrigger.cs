using UnityEngine;

public class ImposterEnterTrigger : MonoBehaviour
{
    public CharacterInformation сharacterInformation;
    public SpriteRenderer spriteRenderer;

    // Поля для сохранения исходного состояния персонажа
    private int originalCharacterID;
    private string originalCharacterName;
    private string originalPosition;
    private int originalAge;
    private string[] accessibleRooms;
    private Gender originalGender;
    private Sprite originalSprite;

    void OnTriggerEnter2D(Collider2D imposter)
    {
        if (imposter.CompareTag("Imposter"))
        {
            CharacterInformation imposterCharacterInformation = imposter.GetComponent<CharacterInformation>();
            SpriteRenderer imposterSpriteRenderer = imposter.GetComponent<SpriteRenderer>();

            if (imposterCharacterInformation != null && imposterSpriteRenderer != null)
            {
                // Сохраняем исходное состояние
                originalCharacterID = imposterCharacterInformation.characterID;
                originalCharacterName = imposterCharacterInformation.characterName;
                originalPosition = imposterCharacterInformation.position;
                originalAge = imposterCharacterInformation.age;
                originalGender = imposterCharacterInformation.gender;
                accessibleRooms = imposterCharacterInformation.accessibleRooms;

                originalSprite = imposterSpriteRenderer.sprite;

                // Изменяем свойства персонажа
                imposterCharacterInformation.CopyFrom(сharacterInformation);
                
                imposterSpriteRenderer.sprite = spriteRenderer.sprite;
            }
        }
    }

    void OnTriggerExit2D(Collider2D imposter)
    {
        if (imposter.CompareTag("Imposter"))
        {
            CharacterInformation imposterCharacterInformation = imposter.GetComponent<CharacterInformation>();
            SpriteRenderer imposterSpriteRenderer = imposter.GetComponent<SpriteRenderer>();

            if (imposterCharacterInformation != null && imposterSpriteRenderer != null)
            {
                // Восстанавливаем исходное состояние
                imposterCharacterInformation.characterID = originalCharacterID;
                imposterCharacterInformation.characterName = originalCharacterName;
                imposterCharacterInformation.position = originalPosition;
                imposterCharacterInformation.age = originalAge;
                imposterCharacterInformation.gender = originalGender;
                imposterCharacterInformation.accessibleRooms = accessibleRooms;

                imposterSpriteRenderer.sprite = originalSprite;
            }
        }
    }
}
