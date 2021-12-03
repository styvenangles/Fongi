using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private FongiControls fongiControls;

    private void Awake()
    {
        fongiControls = new FongiControls();
    }

    void Update()
    {
       
    }

    void OnPause()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }

    void Paused()
    {
        fongiMain.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        fongiMain.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
