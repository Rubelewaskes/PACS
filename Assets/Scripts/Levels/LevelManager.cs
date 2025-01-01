using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public abstract class LevelManager : MonoBehaviour
{
    public GameObject[] hints;
    protected bool[] wasHints;

    public abstract void Start();

    protected void ShowHintByID(int id){
        if (!wasHints[id])
        {
            hints[id].SetActive(true);
        }
    }

    protected void CloseHints(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            if (!wasHints[i]){
                wasHints[i] = true;
                hints[i].SetActive(false);
            }
        }
    }
}