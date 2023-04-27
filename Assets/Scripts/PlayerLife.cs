using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Rigidbody2D rb; // set trọng lực
    private Animator anim; // set animation

    private void Start()
    {
        // get trọng lực
        rb = GetComponent<Rigidbody2D>();
        // get animation
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D obstacle) // hàm sử lí va chạm (hàm mặc định của unity)
    {
        if (obstacle.gameObject.tag == "Trap") // chech va chạm bằng tag
        {
            Die(); // sử lí die
        }
    }

    private void Die()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("die", 1);
        rb.bodyType = RigidbodyType2D.Static; // ko cho player di chuyển (bị đóng băng)
        anim.SetTrigger("death"); // chạy animation death
    }

    private void RestartLevel() // replay lại trò chơi
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
