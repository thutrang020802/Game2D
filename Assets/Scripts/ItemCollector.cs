using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0; // số lượng đếm ăn quả cherri
    [SerializeField] private Text cherriesText; // texxt hiển thị trên màn hình

    private void OnTriggerEnter2D(Collider2D collision) // hàm va chạm
    {
        if (collision.gameObject.tag == "Cherry")
        {
            FindObjectOfType<AudioManager>().PlayOneShot("cherry", 1.25f);
            Destroy(collision.gameObject); //xóa quả chêrri trên màn hình đi
            cherries++; // tăng số lượng lên 1
            cherriesText.text = "Cherries: " + cherries;// cập nhập lại số lượng quả cherri
        }
    }
}
