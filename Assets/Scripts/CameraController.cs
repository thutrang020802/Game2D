using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int IndexMusicSound;

    private void Start()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().PlayMusic($"BGM_0{IndexMusicSound}", 1);
        }
        else
        {
            Instantiate(Resources.Load<GameObject>("AudioManger"), transform);
        }
    }

    private void Update()
    {
        // follow player với trục X, trục Y và Z giữ nguyên
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
