using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // Целевое соотношение сторон

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateAspectRatio();
    }

    void UpdateAspectRatio()
    {
        // Текущее соотношение сторон экрана
        float windowAspect = (float)Screen.width / Screen.height;

        // Отношение целевого и текущего
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Если экран уже, чем 16:9, добавляем чёрные полосы сверху и снизу
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            cam.rect = rect;
        }
        else
        {
            // Если экран шире, чем 16:9, добавляем чёрные полосы слева и справа
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }
    }

    void OnPreCull()
    {
        GL.Clear(true, true, Color.black); // Очищаем области за пределами камеры чёрным цветом
    }

    void Update()
    {
        // Обновляем соотношение при изменении размеров окна
        if (Screen.width / (float)Screen.height != cam.aspect)
        {
            UpdateAspectRatio();
        }
    }
}