using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 dragOffset;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (rectTransform == null || canvas == null)
        {
            Debug.LogError("RectTransform или Canvas не назначен!");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canvas == null || rectTransform == null)
            return;

        // Сохраняем смещение между положением панели и текущей позицией мыши
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out dragOffset
        );

        dragOffset = (Vector2)rectTransform.localPosition - dragOffset;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null || rectTransform == null)
            return;

        Vector2 localMousePosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localMousePosition))
        {
            // Устанавливаем новое положение панели
            rectTransform.localPosition = localMousePosition + dragOffset;

            // Ограничиваем панель границами экрана
            ClampToCanvasBounds();
        }
    }

    private void ClampToCanvasBounds()
    {
        // Получаем границы Canvas
        RectTransform canvasRect = canvas.transform as RectTransform;
        Vector3[] canvasCorners = new Vector3[4];
        canvasRect.GetWorldCorners(canvasCorners);

        Vector3[] panelCorners = new Vector3[4];
        rectTransform.GetWorldCorners(panelCorners);

        Vector3 position = rectTransform.localPosition;

        for (int i = 0; i < 4; i++)
        {
            if (panelCorners[i].x < canvasCorners[0].x)
                position.x += canvasCorners[0].x - panelCorners[i].x;
            else if (panelCorners[i].x > canvasCorners[2].x)
                position.x -= panelCorners[i].x - canvasCorners[2].x;

            if (panelCorners[i].y < canvasCorners[0].y)
                position.y += canvasCorners[0].y - panelCorners[i].y;
            else if (panelCorners[i].y > canvasCorners[2].y)
                position.y -= panelCorners[i].y - canvasCorners[2].y;
        }

        rectTransform.localPosition = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Завершающее действие при отпускании мыши
    }
}
