using UnityEngine;

public class charchterUnselection : MonoBehaviour
{
    private void OnMouseDown()
    {
        CharacterUIHandler characterUIHandler = GetComponent<CharacterUIHandler>();
        if (characterUIHandler != null)
        {
            if (characterUIHandler.IsPanelActive()){
                characterUIHandler.HideInfoMenu();
            }
        }
    }
}
