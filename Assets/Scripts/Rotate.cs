using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // tốc độ xoay

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); // xoay truc Z của object
    }
}
