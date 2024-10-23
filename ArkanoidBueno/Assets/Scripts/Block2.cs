using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour
{
    private int collisionCount = 0; // Contador de colisiones individual para cada bloque
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Asegúrate de que solo se cuenten las colisiones con la "Bola"
        if (collision.gameObject.CompareTag("Ball")) // Asegúrate que la bola tenga el tag "Ball"
        {
            collisionCount++; // Incrementamos el contador solo para este bloque
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            if (collisionCount >= 2) // Si el bloque ha colisionado 2 veces
            {
                Destroy(gameObject); // Destruimos el bloque
                GameManager.Instance.BlockDestroyed();
                //gameManager.AddScore(100);
                FindObjectOfType<GameManager>().AddScore(100);
                
            }
        }
    }
}
