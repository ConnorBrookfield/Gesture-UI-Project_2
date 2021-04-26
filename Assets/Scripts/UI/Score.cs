using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{   
    // === Variables & Auto Properties === // 
    // Score is defined by how many apples have been consumed.
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int ScoreValue { get; set; } = 0;

    // === Update Method === //
    // Changes the scoreText object's text to display the current score.
    void Update()
    {   
        scoreText.text = "Score: " + ScoreValue;
    }
}
