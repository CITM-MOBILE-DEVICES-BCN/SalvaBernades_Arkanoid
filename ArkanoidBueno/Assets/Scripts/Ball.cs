using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier;

    public Rigidbody2D ballRb;
    public bool isBallMoving = false;

    public AudioClip hitSound; // Sonido que se reproducirá al chocar
    private AudioSource audioSourceHit; // Fuente de audio
   

    public GameManager gameManager;

    public Transform playerBar;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        StartCoroutine(ReleaseBallAfterDelay(2f)); // Llamamos a la corrutina con un delay de 2 segundos

        audioSourceHit = gameObject.AddComponent<AudioSource>();
        
    }

    public IEnumerator ReleaseBallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Esperamos los 2 segundos

        if (!isBallMoving)
        {
            transform.parent = null; // Liberamos la bola
            ballRb.velocity = initialVelocity; // Aplicamos la velocidad inicial
            isBallMoving = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.BlockDestroyed();
            gameManager.AddScore(100);
            ballRb.velocity *= velocityMultiplier;
            
        }

        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Block2"))
        {
            PlayHitSound();
        }

      

        //VelocityFixed();

    }
    private void VelocityFixed()
    {
        float velocityDelta = 0.5f;
        float minvelocity = 0.2f;

        if (Mathf.Abs(ballRb.velocity.x) < minvelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(velocityDelta, 0f);
        }

        if (Mathf.Abs(ballRb.velocity.y) < minvelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(0f, velocityDelta);
        }
    }

    void PlayHitSound()
    {
        if (hitSound != null)
        {
            audioSourceHit.PlayOneShot(hitSound); // Reproducir un sonido una vez
        }
    }

   
}

