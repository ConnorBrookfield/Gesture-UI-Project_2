using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // === Variables & Auto Properties === //
    public static bool MovementActive { get; set; }
    public static string VectorDirection { get; set; }
    public List<Transform> SnakeParts = new List<Transform>();      
    private Transform snakeHead;                                    
    private Vector2 moveDirection;                                  

    // === Start Method === //
    // Sets MovementActive to false, VectorDirection to "up",
    // and sets the head of the snake to the start of the list.
    private void Start()
    {
        MovementActive = false;
        VectorDirection = "up";
        snakeHead = SnakeParts[0];                                  
    }

    // === Update Method === //
    // Checks if the GameController is allowing the snake to move,
    // and moves the Snake in a VectorDirection.
    private void Update()
    {
        if(GameController.AllowMovement == true)
        {
            MoveVector(VectorDirection); 
        }
    }

    // === MoveVector Method === //
    // Provides an appropriate vector for moveDirection depending on input.
    // Rotates the snake parts according to the location and position 
    // of the previous part in a list.
    // Sets the snakes head to the moveDirection vector when moving forward/up.
    private void MoveVector(string direction)
    {
        switch (direction)
        {
            case "up":
                moveDirection = Vector2.up;
                break;
            case "down":
                moveDirection = Vector2.down;
                break;
            case "left":
                moveDirection = Vector2.left;
                break;
            case "right":
                moveDirection = Vector2.right;
                break;
        }

        for (int i = SnakeParts.Count - 1; i >= 1; i--)             
        {                                                           
            SnakeParts[i].rotation = SnakeParts[i - 1].rotation;   
            SnakeParts[i].position = SnakeParts[i - 1].position;
        }     
        
        snakeHead.up = moveDirection;                       
        snakeHead.position += snakeHead.up;         
    }

    // === Die Method === //
    // Sets the GameOver state to true
    // and plays the 'game_over' audio.
    public void Die()
    { 
        GameController.IsGameOver = true;
        FindObjectOfType<AudioController>().Play("game_over");
    }

    // === OnTriggerEnter Method === //
    // Checks if the player collides with an object with the "food" tag.
    // If the object matches the food tag, it plays the "apple_crunch" sound,
    // increments the score by 1, adds another body part to the snake and destroys the apple game object.
    // Else, the snake dies (calls the Die() method).
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.CompareTag("food")) 
        {
            FindObjectOfType<AudioController>().Play("apple_crunch");
            Score.ScoreValue += 1;

            Transform lastPart = SnakeParts[SnakeParts.Count - 1];
            GameObject newPart = Instantiate(lastPart.gameObject, lastPart.position - lastPart.up * GameController.Step, lastPart.rotation, transform.parent);
            SnakeParts.Add(newPart.transform);
            
            Destroy(collider.gameObject);
        }
        else
        {
            Die();
        }

    }
}
