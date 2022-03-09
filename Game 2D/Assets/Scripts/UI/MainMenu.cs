using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /* Niveau à charger */
    public string levelToload;

    public GameObject settingsWindow;
    public GameObject introWindow; 
    public GameObject exitConfirmWindow;

    // cette fonction lance le jeu quand on appuye sur le bouton jouer de la popup intro
    public void StartGame()
    {    
        SceneManager.LoadScene(levelToload);
        // introWindow.SetActive(false);
    }

    // cette fonction affiche une sorte de popup avant de démarrer le jeu.
    public void ShowIntro()
    {
        introWindow.SetActive(true);
    }

    // cette fonction affiche fenêtre des options
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        introWindow.SetActive(false);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void exitConfirmWindowShow()
    {
        exitConfirmWindow.SetActive(true);
    }

    public void exitConfirmWindowHidden()
    {
        exitConfirmWindow.SetActive(false);
    }

}
