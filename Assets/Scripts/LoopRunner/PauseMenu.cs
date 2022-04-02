using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private GameObject pauseButton;

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pauseGameMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void StartMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
       Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
