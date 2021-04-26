using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // === Variables & Auto Properties === //
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    public static bool GamePaused { get; set; }
    public static bool IsGameOver { get; set; }
    public static float StepTime { get; set; }
    public static float Delta { get; set; }
    public static float Step { get; set; }
    public static bool AllowMovement { get; set; }
    private int currentLevelIndex;

    // === Start Method === //
    // Sets the initial state for the Game variables.
    // Grabs the Current Scene's build index and
    // plays a different song depending on the scene.
    // Unpauses the game.
    void Start()
    {
        IsGameOver = false;
        GamePaused = false;
        AllowMovement = false;
        StepTime = 0.6f;
        Delta = 0f;
        Score.ScoreValue = 0;
        
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentLevelIndex == 1) 
        {
            FindObjectOfType<AudioController>().Play("game_music");
        }
        else 
        {
            FindObjectOfType<AudioController>().Play("menu_music");
        }
        Time.timeScale = 1f;
    }

    // === Update Method === //
    // When the ESC key is pressed, the game pauses/unpauses.
    // The user can pause if the game scene is loaded.
    // Checks "IsGameOver == true" and calls "GameOver()" if true.
    // Checks delta (addition of the time undertaken between frames) against
    // the predefined stepTime, so that the snake moves every set time interval.
    // Sets the value of AllowMovement depending on the outcome.
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && IsGameOver == false)
        {
            if (GamePaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
        
        if(currentLevelIndex == 1)
        {
            if (GamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if(IsGameOver == true)
        {
            GameOver();
        }

        if (Delta >= StepTime)                                      
        {                                                           
            Delta = 0f;                                             
            AllowMovement = true;
        }                                                           
        else
        {
            AllowMovement = false;
        }
        Delta += Time.deltaTime;                                    
    }

    // === Pause Game Method === //
    // Sets the UI object to active.
    // Stops the timescale of the game.
    // Changes boolean so the game can be unpaused.
    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    // === Resume Game Method === //
    // Deactivates the UI object
    // Starts the timescale of the game
    // Resets the boolean to false
    public void ResumeGame()
    {      
        pauseUI.SetActive(false);       
        Time.timeScale = 1f;      
        GamePaused = false;
    }

    // === Restart Game Method === //
    // Reloads the GameScene.
    public static void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    //=== RestartGame Method ===//
    // Reloads the GameScene.
    // Unity does not allow GUI/Canvas buttons to use static methods,
    // so I created a non static method for mouse navigation.
    public void RestartGameNotStatic()
    {
        SceneManager.LoadScene(1);
    }

    // === GameOver Method === //
    // Changes the timescale so that the gameplay stops.
    // Sets the GameOverScreen object to active.
    public void GameOver()
    {   
        Time.timeScale = 0f;
        Debug.Log("GAME IS OVER - SHOW SCREEN HERE");      
        gameOverUI.SetActive(true);
    }

    // === LoadMainMenu Method === //
    // Loads the MainMenu Scene.
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // === Load Main Menu Screen Method === //
    // Loads the MainMenu Scene.
    // Unity does not allow GUI/Canvas buttons to use static methods,
    // so I created a non static method for mouse navigation.
    public void LoadMainMenuNotStatic()
    {
        SceneManager.LoadScene(0);
    }

    //=== Quit Game Method ===//
    // Quits the unity application.
    public static void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
