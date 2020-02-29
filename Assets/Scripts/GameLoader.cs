using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReloadGame()
    {
        Time.timeScale = 1; // start the game time, because it gets paused on death
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}