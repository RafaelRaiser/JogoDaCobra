using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private int moveX = 1;
    private int moveY = 0;

    void Update()
    {
        // Controles movimentação com as setas do teclado
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveX = 0;
            moveY = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveX = 0;
            moveY = -1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveX = -1;
            moveY = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveX = 1;
            moveY = 0;
        }

        // Move a cobra no eixo X e Y
        transform.position = new Vector3(transform.position.x + moveX * speed, transform.position.y + moveY * speed, 0);
    }
}
