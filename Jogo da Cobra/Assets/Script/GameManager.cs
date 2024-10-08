using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gridSize = 20;
    public GameObject foodPrefab;

    #region Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    void Start()
    {
        // Inicializa a comida
        SpawnFood();
    }

    public void SpawnFood()
    {
        // Spawna a comida em um ponto aleatório do grid
        Instantiate(foodPrefab);
    }
}

