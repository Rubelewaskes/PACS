using UnityEngine;
using TMPro;

public class FillCertScript : MonoBehaviour
{
    public TMP_InputField FIInput;
    public TMP_InputField GroupInput;

    public void SaveCertificateData()
    {
        if (CertificateData.Instance != null)
        {
            CertificateData.Instance.FI = FIInput.text;
            CertificateData.Instance.Group = GroupInput.text;
        }
        else
        {
            Debug.LogError("CertificateData.Instance не найден! Убедитесь, что объект CertificateData существует.");
        }
    }
}
