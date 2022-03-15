using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /* Niveau � charger */
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

    // cette fonction affiche une sorte de popup avant de d�marrer le jeu.
    public void ShowIntro()
    {
        introWindow.SetActive(true);
    }

    // cette fonction affiche fen�tre des options
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    // cette fonction ferme la fen�tre des options
    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        introWindow.SetActive(false);
    }

    // cette fonction ouvre la scene qui contient les cr�dits
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    // cette fonction permet de quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }

    // TODO : les deux fonctions qui suivent sont surement fusionnables

    // cette fonction affiche la fen�tre qui demande une confirmation avant de quitter le jeu
    public void exitConfirmWindowShow()
    {
        exitConfirmWindow.SetActive(true);
    }

    // cette fonction masque la fen�tre qui demande une confirmation avant de quitter le jeu
    public void exitConfirmWindowHidden()
    {
        exitConfirmWindow.SetActive(false);
    }

}
