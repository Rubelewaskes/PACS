using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ButtonsFillScript : MonoBehaviour
{
    public List<CharacterInformation> charInfo;
    public List<TextMeshProUGUI> buttonsText; 

    public void Filling()
    {
        if (buttonsText != null && charInfo != null)
        {
            for (int i = 0; i < 10; i++)
            {
                
                if (buttonsText[i] != null && charInfo[i] != null)
                {
                    buttonsText[i].text = charInfo[i].characterName;
                }
            }
        }
    }
}
