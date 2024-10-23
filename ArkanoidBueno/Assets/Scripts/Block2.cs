using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour
{
    private int collisionCount = 0; // Contador de colisiones individual para cada bloque
    public GameManager gameManager; // Referencia al GameManager


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Asegúrate de que solo se cuenten las colisiones con la "Bola"
        if (collision.gameObject.CompareTag("Ball")) // Asegúrate que la bola tenga el tag "Ball"
        {
            collisionCount++; // Incrementamos el contador solo para este bloque

            if (collisionCount >= 2) // Si el bloque ha colisionado 2 veces
            {
                Destroy(gameObject); // Destruimos el bloque
                GameManager.Instance.BlockDestroyed();
                gameManager.AddScore(100);
                
            }
        }
    }
}
