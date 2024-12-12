using UnityEngine;

public class DoorTrigger : MonoBehaviour
{   
    public JournalController journalController;
    public SpriteRenderer doorRenderer;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (doorRenderer != null)
            {
                doorRenderer.color = new Color(121/255f,221/255f,126/255f);
            }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (doorRenderer != null)
            {
                doorRenderer.color = new Color(212/255f, 86/255f, 85/255f); 
                
                string message = $"{other.name} прошёл через дверь в {gameObject.name}";
                journalController.AddEntry(message, other.gameObject);
            }

    }
}
