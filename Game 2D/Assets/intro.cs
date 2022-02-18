using UnityEngine.SceneManagement;
using UnityEngine;

public class intro : MonoBehaviour
{

    public string levelToload;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }

}
