using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic("BGM_01", 1);
    }

    public void StartGame()
    {
        // chạy scene đầu tiên +1 (level 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Setting()
    {
        Debug.Log("Setting Coming Soon"); 
    }

    public void Exit()
    {
        // thoát game
        Application.Quit();
    }
}
