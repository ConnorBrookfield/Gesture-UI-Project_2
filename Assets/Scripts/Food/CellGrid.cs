using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    // === Auto Properties === //
    public Vector2 Position { get; set; }
    public bool IsEmpty { get; set; }
}

public class CellGrid : MonoBehaviour
{
    // === Variables & Auto Properties === //
    private const int width = 14, height = 9;
    private const float cellSize = 1f;
    private static List<Cell> grid = new List<Cell>();
    public static List<Cell> emptyCells { get; set; }  = new List<Cell>();
    private Snake snake;

    // === Start Method === //
    // This provides values for snake, GameController.Step and
    // creates a grid and sets the empty cells.
    void Start()
    {
        snake = FindObjectOfType<Snake>();
        GameController.Step = cellSize;
        CreateGrid();
        SetCells();
    }

    // === Update Method === //
    // Compares the GameController's Delta and StepTime,
    // and updates the cells the snake is oocupying.
    void Update()
    {
        if (GameController.Delta >= GameController.StepTime)
        {
            SetCells();
        }
    }

    // === SetCells Method === //
    // This method checks what cells in the grid the Snake is occupying,
    // and states whether or not each cell is empty or not.
    void SetCells()
    {
        foreach (Cell cell in grid)
        {
            foreach(Transform part in snake.SnakeParts)
            {
                if((Vector2)part.position == cell.Position)
                {
                    cell.IsEmpty = false;
                }
                else
                {
                    cell.IsEmpty = true;
                }
            }
            if (cell.IsEmpty)
            {
                emptyCells.Add(cell);
            }
        }
    }

    // === CreateGrid Method === //
    // Creates a grid of cells based on whether cells are empty or not.
    void CreateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j=0; j <height; j++)
            {
                grid.Add(new Cell() {
                    Position = new Vector2(-width / 2f + i * cellSize, -height / 2f + j * cellSize)
                });
            }
        }
    }
}
