using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner: MonoBehaviour
{
    public GameObject foodPrefab; 
    public float minX = -9f, maxX = 9f, minY = -5f, maxY = 5f; 

    //Chamar o Método SpawnFood
    void Start()
    {
        SpawnFood();
    }

    // Método que spawnar a comida aleatoriamente dentro dos limites do grid
    void SpawnFood()
    {
        float randomX = Mathf.Round(Random.Range(minX, maxX)); // Posição aleatória no eixo X
        float randomY = Mathf.Round(Random.Range(minY, maxY)); // Posição aleatória no eixo Y

        // Instancia a comida na posição gerada aleatoriamente
        Instantiate(foodPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
    }
}