using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private void Start()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().PlayMusic("BGM_01", 1);
        }
        else
        {
            Instantiate(Resources.Load<GameObject>("AudioManger"), transform);
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0); // trở lại scene đầu tiên
    }

    public void Quit()
    {
        Application.Quit();// thoát game
    }
}
