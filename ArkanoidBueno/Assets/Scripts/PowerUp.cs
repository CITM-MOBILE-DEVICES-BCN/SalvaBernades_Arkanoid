using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject playerPaddle; // Referencia a la plataforma del jugador
    public GameObject ball; // Referencia a la pelota
    public float scaleMultiplier = 2f; // Cu�nto se va a escalar la plataforma
    public float powerUpDuration = 5f; // Duraci�n del efecto del power-up
    private Vector3 originalScale; // Para almacenar el tama�o original de la plataforma
    private bool powerUpActive = false; // Para rastrear si el power-up est� activo

    void Start()
    {
        // Obtener el tama�o original de la plataforma
        originalScale = playerPaddle.transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Aplicar el efecto del power-up
            ActivatePowerUp();

            // Destruir el objeto del power-up
            Destroy(gameObject);
        }
    }

    void ActivatePowerUp()
    {
        // Desvincular la pelota del jugador para que no se vea afectada por el escalado
        if (ball != null && ball.transform.parent == playerPaddle.transform)
        {
            ball.transform.parent = null; // Desvincular la pelota
        }

        // Duplicar el tama�o de la plataforma
        playerPaddle.transform.localScale = new Vector3(originalScale.x * scaleMultiplier, originalScale.y, originalScale.z);
        powerUpActive = true;

        // Devolver el tama�o original despu�s de un tiempo
        Invoke("ResetPaddleSize", powerUpDuration);
    }

    public void ResetPaddleSize()
    {
        if (powerUpActive)
        {
            // Restaurar el tama�o original de la plataforma
            playerPaddle.transform.localScale = originalScale;
            powerUpActive = false;
        }
    }

   
}
