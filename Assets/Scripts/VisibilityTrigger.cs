using UnityEngine;

public class VisibilityTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
    }
}