using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float bounds = 4.5f;
    public Slider movementSlider; // El Slider que controla el movimiento
    public float platformYPosition = -4f; // Posici�n fija en Y (ajusta seg�n la altura de tu plataforma)
    public float movementSpeed = 10f; // Velocidad de movimiento (opcional para suavizar el movimiento)
    public GameObject ball; // Referencia a la pelota
    private bool followBall = false; // Controla si la plataforma sigue a la pelota
    private Vector2 initialPosition; // Posici�n inicial de la plataforma

    private void Start()
    {
        initialPosition = transform.position;
    }


    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            followBall = !followBall; // Cambiar el estado de seguimiento
        }

        // Si la plataforma debe seguir a la pelota
        if (followBall && ball != null)
        {
            FollowBall(); // Ejecutar la l�gica de seguimiento
        }
        else
        {
            Move();
            // Actualizar la posici�n de la plataforma en funci�n del valor del Slider
            float sliderValue = movementSlider.value;

            // Mover la plataforma solo en el eje X usando el valor del Slider
            Vector2 newPosition = new Vector2(sliderValue, platformYPosition);

            // Actualizamos la posici�n de la plataforma (puedes a�adir movimiento suave con Lerp si lo prefieres)
            transform.position = newPosition;
        }

    }

    void FollowBall()
    {
        // Obtener la posici�n de la pelota solo en el eje X
        float ballX = ball.transform.position.x;

        // Mover la plataforma hacia la posici�n de la pelota en el eje X
        Vector2 targetPosition = new Vector2(ballX, initialPosition.y);

        // Movimiento suave usando MoveTowards
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds);
        transform.position = playerPosition;
    }
}
