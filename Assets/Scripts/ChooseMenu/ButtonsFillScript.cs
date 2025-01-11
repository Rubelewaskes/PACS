using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonsFillScript : MonoBehaviour
{
    public CharacterManager characterManager;

    public void Filling(int rightButtonIndex, Button[] varButtons)
    {
        varButtons[rightButtonIndex].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(0);
        if (rightButtonIndex == 0) {
            varButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(1);
            varButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(2);
        } else if (rightButtonIndex == 1) {
            varButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(1);
            varButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(2);
        } else if (rightButtonIndex == 2) {
            varButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(1);
            varButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(2);
        }

        for (int i = 3; i < varButtons.Length; i++) {
            int index = i;
            varButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = characterManager.GetCharacterNameById(index);
        }
    }
}
