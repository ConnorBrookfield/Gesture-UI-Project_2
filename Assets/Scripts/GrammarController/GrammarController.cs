using UnityEngine;
using UnityEngine.Windows.Speech;

public class GrammarController : MonoBehaviour
{
    // === Variables === //
    private GrammarRecognizer gr;

    // === Start Method === //
    // Checks '/StreamingAssets' for 'SimpleGrammar.xml' and reads it.
    // It uses that grammar for the GrammarRecognizer with a low confidence level.
    private void Start()
    {
        gr = new GrammarRecognizer(Application.streamingAssetsPath + "/SimpleGrammar.xml", ConfidenceLevel.Low);
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Grammar loaded and recogniser started!");
    }

    // === GR_OnPhraseRecognized Method === //
    // Reads the semantic meanings from the args passed in.
    // Semantic meanings are returned as key/value pairs and a
    // foreach is used to get all the meanings.
    // It trims the 0th meaning value, and compares the
    // valueString's value is with different switch cases.
    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SemanticMeaning[] meanings = args.semanticMeanings;

        foreach(SemanticMeaning meaning in meanings)
        {
            string valueString = meaning.values[0].Trim();

            switch (valueString)
            {
                case "up":
                case "down":
                case "left":
                case "right":
                    Debug.Log("Moving " + valueString + "...");
                    Snake.VectorDirection = valueString;
                    break;
                case "play":
                    Debug.Log("Restarting game...");
                    GameController.RestartGame();
                    break;
                case "pause":
                    Debug.Log("Pausing game...");
                    GameController.GamePaused = true;
                    break;
                case "resume":
                    Debug.Log("Resuming game...");
                    GameController.GamePaused = false;
                    break;
                case "quit":
                    Debug.Log("Quitting game...");
                    GameController.QuitGame();
                    break;
                case "mainMenu":
                    Debug.Log("Going to the main menu...");
                    GameController.LoadMainMenu();
                    break;
                case "increaseVol":
                    Debug.Log("Increasing volume...");
                    MasterVolumeSlider.ChangeCurrentVolume(10);
                    break;
                case "decreaseVol":
                    MasterVolumeSlider.ChangeCurrentVolume(-10);
                    Debug.Log("Decreasing volume...");
                    break;
                default:
                    break;
            }
        }    
    }

    // === OnApplicationQuit Method === //
    // Stops the Grammar Recogniser when the application is closing.
    private void OnApplicationQuit()
    {
        if(gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }
}
