using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    /* fonction qui charge le Main Menu � la fin des cr�dits */

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /* On appuye sur ESC pour skip les cr�dits */

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
