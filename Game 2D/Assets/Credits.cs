using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    /* fonction qui charge le Main Menu à la fin des crédits */

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /* On appuye sur ESC pour skip les crédits */

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
