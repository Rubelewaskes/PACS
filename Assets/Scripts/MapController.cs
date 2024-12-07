using UnityEngine;
using Unity.AI;
using Unity.AI.Navigation;


public class MapController : MonoBehaviour
{
    public Transform gameField; // Группа, содержащая карту
    public NavMeshSurface navMeshSurface; // Навигационная поверхность

    public float panSpeed = 1f; // Скорость перемещения
    public float zoomSpeed = 0.5f; // Скорость масштабирования
    public float minZoom = 0.5f; // Минимальный размер карты
    public float maxZoom = 2f; // Максимальный размер карты

    private Vector3 dragStartPosition;
    private Vector3 originalPosition;

    void Start()
    {
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh(); // Построение начальной сетки
        }
    }

    void Update()
    {
        HandlePan();
        HandleZoom();
    }

    void HandlePan()
    {
        if (Input.GetMouseButtonDown(0)) // Начало перетаскивания
        {
            dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            originalPosition = gameField.position;
        }

        if (Input.GetMouseButton(0)) // Во время перетаскивания
        {
            Vector3 currentDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = currentDragPosition - dragStartPosition;

            gameField.position = originalPosition + difference; // Сдвигаем карту
            UpdateNavMesh(); // Обновляем сетку
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Получаем ввод от колёсика мыши
        if (scroll != 0)
        {
            Vector3 scale = gameField.localScale;
            float newScale = Mathf.Clamp(scale.x + scroll * zoomSpeed, minZoom, maxZoom);

            gameField.localScale = new Vector3(newScale, newScale, scale.z); // Масштабируем карту
            UpdateNavMesh(); // Обновляем сетку
        }
    }

    void UpdateNavMesh()
    {
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh(); // Перестроение навигационной сетки
        }
    }
}
