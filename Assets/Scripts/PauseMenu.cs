using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;  
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenSettings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true); 
    }
    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true); 
    }

    public void MainMenu()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}

