using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision) // sử lí va chạm
    {
        if (collision.gameObject.name == "Player" && levelCompleted == false)
        {
            collision.GetComponent<PlayerLife>().rb.bodyType = RigidbodyType2D.Static;
            FindObjectOfType<AudioManager>().PlayOneShot("win", 1);
            levelCompleted = true;
            Invoke(nameof(CompleteLevel), .5f); // delay 0.5s thì sang màn tiếp theo
        } 
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // cộng scene theo index
    }
}
