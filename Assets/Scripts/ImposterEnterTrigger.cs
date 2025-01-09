using UnityEngine;

public class ImposterEnterTrigger : MonoBehaviour
{
    public CharacterInformation сharacterInformation;
    public SpriteRenderer spriteRenderer;

    // Поля для сохранения исходного состояния персонажа
    private CharacterInformation originalCharacterInformation;
    private Sprite originalSprite;
    private Color originalColor;

    void OnTriggerEnter2D(Collider2D imposter)
    {
        if (imposter.CompareTag("Imposter"))
        {
            CharacterInformation imposterCharacterInformation = imposter.GetComponent<CharacterInformation>();
            SpriteRenderer imposterSpriteRenderer = imposter.GetComponent<SpriteRenderer>();

            if (imposterCharacterInformation != null && imposterSpriteRenderer != null)
            {
                // Сохраняем исходное состояние
                originalCharacterInformation = new CharacterInformation();
                originalCharacterInformation.CopyFrom(imposterCharacterInformation);

                originalSprite = imposterSpriteRenderer.sprite;
                originalColor = imposterSpriteRenderer.color;

                // Изменяем свойства персонажа
                imposterCharacterInformation.CopyFrom(сharacterInformation);
                imposterSpriteRenderer.sprite = spriteRenderer.sprite;
                imposterSpriteRenderer.color = spriteRenderer.color;
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
                if (originalCharacterInformation != null)
                {
                    imposterCharacterInformation.CopyFrom(originalCharacterInformation);
                }

                if (originalSprite != null)
                {
                    imposterSpriteRenderer.sprite = originalSprite;
                }

                imposterSpriteRenderer.color = originalColor;
            }
        }
    }
}
