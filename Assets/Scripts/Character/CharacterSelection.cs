using UnityEngine;
using UnityEngine.Events; 

public class CharacterSelection : MonoBehaviour
{
    public UnityEvent chooseCharacter;
    public UnityEvent TriggerMouseDown;

    public void OnMouseDown()
    {
        CharacterUIHandler characterUIHandler = GetComponent<CharacterUIHandler>();
        if (characterUIHandler != null)
        {
            if (!characterUIHandler.IsPanelActive())
            {
                characterUIHandler.SetText();
                characterUIHandler.ShowInfoMenu();
                chooseCharacter?.Invoke();
            }
            else
            {
                characterUIHandler.SetText();
                chooseCharacter?.Invoke();
            }
        }
    }

    public void TriggerOnMouseDown()
    {
        TriggerMouseDown?.Invoke();
    }
}
