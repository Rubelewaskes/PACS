
using UnityEngine;
using TMPro;

public class CreateCertScript : MonoBehaviour
{
    public TMP_Text txtField2;   
    public TMP_Text txtField3;   

    string endDate = System.DateTime.Now.ToString("dd.MM.yyyy");
            
    private string txt2;
    private string txt3;
    
    void Start(){
        if (CertificateData.Instance != null)
        {
            txt2 = "Данный сертификат поддтверждает, что студент группы "+ CertificateData.Instance.FI + " " + CertificateData.Instance.Group + " успешно прошёл обучение в тренажёре СКУД и получил базовые знания о целях использования систем контроля и управления доступом.";
            txt3 = "Дата " + endDate;
            txtField2.text = txt2;
            txtField3.text = txt3;
        }
        else
        {
            Debug.LogError("CertificateData.Instance не найден! Убедитесь, что объект CertificateData существует.");
        }
    }
}