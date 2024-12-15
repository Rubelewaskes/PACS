using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public abstract class LevelManager : MonoBehaviour
{

    public abstract void LoadNextScene();
    public abstract void HideHint4();
    public abstract IEnumerator ShowHint4();
    public abstract void ShowCharacterInfo();
}