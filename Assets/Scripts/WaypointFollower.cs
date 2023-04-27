using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // tạo các điểm di chuyển của vật cản
    private int currentWaypointIndex = 0; // điểm mà vật cản đi tới

    [SerializeField] private float speed = 2f; // tốc độ di chuyển

    private void Update()
    {
        // tính khoảng cách của vật cản với điểm đến
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // ngoài mảng thì reset = 0
            {
                currentWaypointIndex = 0;
            }
        }

        // di chuyển vật cản
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
