using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> snakeBodyParts = new List<Transform>();
    public GameObject snakeBodyPrefab;
    public float moveSpeed = 0.5f;
    private Vector2 moveDirection = Vector2.right;
    private float stepTimer = 0f;

    void Start()
    {
        // Inicializa a cobra com o primeiro corpo
        InvokeRepeating(nameof(MoveSnake), moveSpeed, moveSpeed);
    }

    void Update()
    {
        // Controle de direção via teclado
        if (Input.GetKeyDown(KeyCode.W) && moveDirection != Vector2.down) moveDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S) && moveDirection != Vector2.up) moveDirection = Vector2.down;
        if (Input.GetKeyDown(KeyCode.A) && moveDirection != Vector2.right) moveDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.D) && moveDirection != Vector2.left) moveDirection = Vector2.right;
    }

    void MoveSnake()
    {
        // Movimenta a cobra
        Vector2 previousPosition = transform.position;
        transform.Translate(moveDirection);

        // Teletransporte nas bordas do grid
        if (transform.position.x >= GameManager.instance.gridSize)
            transform.position = new Vector2(-GameManager.instance.gridSize, transform.position.y);
        else if (transform.position.x < -GameManager.instance.gridSize)
            transform.position = new Vector2(GameManager.instance.gridSize, transform.position.y);
        else if (transform.position.y >= GameManager.instance.gridSize)
            transform.position = new Vector2(transform.position.x, -GameManager.instance.gridSize);
        else if (transform.position.y < -GameManager.instance.gridSize)
            transform.position = new Vector2(transform.position.x, GameManager.instance.gridSize);

        // Movimenta o corpo da cobra
        for (int i = snakeBodyParts.Count - 1; i > 0; i--)
        {
            snakeBodyParts[i].position = snakeBodyParts[i - 1].position;
        }
        if (snakeBodyParts.Count > 0)
            snakeBodyParts[0].position = previousPosition;
    }

    public void Grow()
    {
        // Adiciona uma nova parte do corpo quando comer comida
        GameObject newPart = Instantiate(snakeBodyPrefab);
        newPart.transform.position = snakeBodyParts[snakeBodyParts.Count - 1].position;
        snakeBodyParts.Add(newPart.transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se colidiu com comida
        if (other.CompareTag("Food"))
        {
            Grow();
            Destroy(other.gameObject);
            GameManager.instance.SpawnFood();
        }
    }
}
