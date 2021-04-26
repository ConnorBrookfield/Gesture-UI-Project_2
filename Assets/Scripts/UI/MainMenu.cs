using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // === PlayGame Method === //
    // Loads the Game Scene at index 1 of the build order.
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // === QuitGame Method === //
    // Quits the unity application.
    public void QuitGame(){
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
