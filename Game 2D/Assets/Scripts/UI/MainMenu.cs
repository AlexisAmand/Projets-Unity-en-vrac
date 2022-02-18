using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /* Niveau à charger */
    public string levelToload;

    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
