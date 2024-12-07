using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints; // Точки маршрута
    public float[] waitTimes; // Время ожидания на каждой точке

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private float waitTimer = 0f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (waypoints.Length > 0)
            agent.SetDestination(waypoints[currentWaypointIndex].position);

        // Отключаем изменение ориентации по оси Z
        agent.updateUpAxis = false;

        // Отключаем вращение по оси Y
        agent.updateRotation = false;

        // Устанавливаем начальное время ожидания
        waitTimer = GetWaitTimeForCurrentWaypoint();
    }

    void Update()
    {
        // Проверяем, достиг ли персонаж текущей точки
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (waitTimer <= 0f) // Если таймер ожидания истёк
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
                waitTimer = GetWaitTimeForCurrentWaypoint(); // Устанавливаем время ожидания для следующей точки
            }
            else
            {
                waitTimer -= Time.deltaTime; // Отсчитываем время ожидания
            }
        }

        // Поворачиваем спрайт в направлении движения
        Vector3 velocity = agent.desiredVelocity;
        if (velocity.x > 0.1f)
            spriteRenderer.flipX = false; // Смотрим вправо
        else if (velocity.x < -0.1f)
            spriteRenderer.flipX = true; // Смотрим влево
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
}