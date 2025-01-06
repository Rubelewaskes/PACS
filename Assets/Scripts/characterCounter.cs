using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class charCounter : MonoBehaviour
{
    public TMP_Text countText;

    private int count = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        count++;
        countText.text = count.ToString();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        count--;
        countText.text = count.ToString();
    }
}