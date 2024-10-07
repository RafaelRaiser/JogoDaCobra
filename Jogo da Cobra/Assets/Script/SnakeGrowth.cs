using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGrowth : MonoBehaviour
{
    public GameObject snakePrefab; 
    private List<GameObject> snakeParts = new List<GameObject>(); 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")) // Verifica se tocou em comida
        {
            GrowSnake(); // Cresce a cobra
            Destroy(other.gameObject); // Remove a comida da tela
        }
    }

    
}
