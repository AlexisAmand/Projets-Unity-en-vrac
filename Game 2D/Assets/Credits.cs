using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    /* fonction qui charge le Main Menu � la fin des cr�dits */

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /* Si on appuye sur ESC, �a skip les cr�dits et �a charge le Main Menu */

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // SceneManager.LoadScene("MainMenu");
            LoadMainMenu();
        }

    }
}
