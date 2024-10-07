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
    // M�todo que faz a cobra crescer
    void GrowSnake()
    {
        // Pega a �ltima parte da cobra ou a cabe�a, se ainda n�o houver corpo
        Vector3 newPosition = (snakeParts.Count == 0) ? transform.position : snakeParts[snakeParts.Count - 1].transform.position;

        // Instancia uma nova parte do corpo e a adiciona � lista
        GameObject newBodyPart = Instantiate(snakePrefab, newPosition, Quaternion.identity);
        snakeParts.Add(newBodyPart);
    }
}
