using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /* Niveau � charger */
    public string levelToload;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }

    public void SettingsButton()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
