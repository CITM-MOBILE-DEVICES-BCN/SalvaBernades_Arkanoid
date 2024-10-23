using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    private int triggerTimes = 0;
    public Ball ball;
    public Player player;
    public GameManager gameManager;
    public SceneManager sceneManager;

    public AudioClip deathSound; // Sonido que se reproducirá al morir
    private AudioSource audioSourceDeath; // Fuente de audio


    // Start is called before the first frame update
    void Start()
    {
        audioSourceDeath = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Detenemos el movimiento de la pelota
            ball.ballRb.velocity = Vector2.zero;

            // Recolocamos la pelota en la posición de la barra del jugador
            ball.transform.position = player.transform.position;

            // Volvemos a vincular la pelota a la barra (si lo necesitas)
            ball.transform.parent = ball.playerBar;

            ball.isBallMoving = false; // Reseteamos el estado de movimiento

            // Iniciamos nuevamente el lanzamiento con un retraso de 2 segundos
            StartCoroutine(ball.ReleaseBallAfterDelay(2f));

            //gameManager.DecreaseLife();
            FindObjectOfType<GameManager>().DecreaseLife();

            PlayDeathSound();

            triggerTimes++;
            if(triggerTimes >= 3)
            {
               SceneManager.LoadScene("GameOver");
            }
        }
    }

    void PlayDeathSound()
    {
        if (deathSound != null)
        {
            audioSourceDeath.PlayOneShot(deathSound); // Reproducir un sonido una vez
        }
    }

}
