using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PatrolScript : MonoBehaviour
{
    public Transform[] waypoints; // Точки маршрута
    public float[] waitTimes; // Время ожидания на каждой точке

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private float waitTimer = 0f;

    private SpriteRenderer spriteRenderer;

    public UnityEvent PatrolComplete;

    private bool isPatrolComplete = false; // Флаг завершения патруля

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (waypoints.Length > 0)
            agent.SetDestination(waypoints[currentWaypointIndex].position);

        // Отключаем вращение NavMeshAgent
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Устанавливаем начальное время ожидания
        waitTimer = GetWaitTimeForCurrentWaypoint();
    }

    void Update()
    {
        if (isPatrolComplete) return; // Если патруль завершён, больше ничего не делаем

        if (waypoints.Length > 0)
        {
            // Проверка на паузу
            if (PauseManager.IsPaused)
            {
                agent.velocity = Vector3.zero; // Останавливаем движение
                return;
            }

            // Проверяем, достиг ли персонаж текущей точки
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (waitTimer <= 0f) // Если таймер ожидания истёк
                {
                    // Если это последняя точка маршрута
                    if (currentWaypointIndex == waypoints.Length - 1)
                    {
                        OnPatrolComplete(); // Вызов события завершения патрулирования
                        return; // Завершаем обновление
                    }

                    // Переход к следующей точке
                    currentWaypointIndex++;
                    agent.SetDestination(waypoints[currentWaypointIndex].position);
                    waitTimer = GetWaitTimeForCurrentWaypoint(); // Устанавливаем время ожидания для следующей точки
                }
                else
                {
                    waitTimer -= Time.deltaTime; // Отсчитываем время ожидания
                }
            }

            // Поворачиваем спрайт в направлении движения
            UpdateSpriteRotation();
        }
    }

    private void UpdateSpriteRotation()
    {
        Vector3 velocity = agent.velocity;

        if (velocity.sqrMagnitude > 0.01f) // Убедимся, что персонаж действительно движется
        {
            // Рассчитываем угол поворота на основе направления движения
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

            // Устанавливаем вращение для персонажа
            transform.rotation = Quaternion.Euler(0, 0, angle + 90); // Смещаем угол на -90°, чтобы персонаж смотрел вперёд
        }
    }

    private float GetWaitTimeForCurrentWaypoint()
    {
        // Возвращает время ожидания для текущей точки, если оно указано
        if (waitTimes != null && currentWaypointIndex < waitTimes.Length)
        {
            return waitTimes[currentWaypointIndex];
        }
        return 0f; // Если не задано, ждать не нужно
    }

    public void OnPatrolComplete()
    {
        isPatrolComplete = true; // Устанавливаем флаг завершения патруля
        agent.isStopped = true; // Останавливаем NavMeshAgent
        PatrolComplete?.Invoke(); // Вызываем событие завершения патруля
    }
}
