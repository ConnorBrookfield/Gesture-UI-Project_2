using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // === Variables === //
    public GameObject food;

    // === Update Method === //
    // Spawns a food object if non have already been spawned.
    void Update()
    {
        if (transform.childCount == 0)
        {
            SpawnFood();
        }
    }

    // === SpawnFood Method === //
    // Instantiates a food object in a random available cell within the CellGrid.
    void SpawnFood()
    {
        Cell randomCell = CellGrid.emptyCells[Random.Range(0, CellGrid.emptyCells.Count - 1)];

        Instantiate(food, randomCell.Position, Quaternion.identity, transform);
    }
}
