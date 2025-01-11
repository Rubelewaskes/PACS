using UnityEngine;

public class CertificateData : MonoBehaviour
{
    public static CertificateData Instance;

    public string FI; // Фамилия Имя
    public string Group; // Группа

    private void Awake()
    {
        // Проверяем, чтобы был только один экземпляр
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject);
        }
    }
}