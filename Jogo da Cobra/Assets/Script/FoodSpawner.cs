using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner: MonoBehaviour
{
    void Start()
    {
        // Define uma posi��o aleat�ria no grid
        transform.position = new Vector2(
            Random.Range(-GameManager.instance.gridSize, GameManager.instance.gridSize),
            Random.Range(-GameManager.instance.gridSize, GameManager.instance.gridSize)
        );
    }
}