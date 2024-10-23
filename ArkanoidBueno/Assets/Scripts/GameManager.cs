using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int totalBlocks;

    public int lives = 3; // Número de vidas
    public int score = 0;
    public int highScore = 0;

    //public TMP_Text livesText;
    //public TMP_Text scoreText;
    //public TMP_Text highScoreText;

    Scene currentScene;
    private string sceneName;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        totalBlocks = GameObject.FindGameObjectsWithTag("Block").Length + GameObject.FindGameObjectsWithTag("Block2").Length;

        FindObjectOfType<TextManager>().UpdateLivesText();
        FindObjectOfType<TextManager>().UpdateScoreText();
        FindObjectOfType<TextManager>().UpdateHighScoreText();

        BlockDestroyed();

        Scene currentScene = SceneManager.GetActiveScene();

        // Obtener el nombre de la escena
        sceneName = currentScene.name;
    }

    private void Update()
    {
        Debug.Log("totalblocks: " + totalBlocks);
    }

    public void BlockDestroyed()
    {
        totalBlocks--;
        
        if (totalBlocks <= 1)
        {
            LoadNextLevel();
            totalBlocks = GameObject.FindGameObjectsWithTag("Block").Length + GameObject.FindGameObjectsWithTag("Block2").Length;
            
        }
    }

    public void DecreaseLife()
    {
        lives--; // Disminuye el contador de vidas
        FindObjectOfType<TextManager>().UpdateLivesText(); // Actualiza el texto en el Canvas

        if (lives <= 0)
        {
            GameOver(); // Lógica para manejar el fin del juego
        }
    }

    public void AddScore(int points) // Método para aumentar la puntuación
    {
        score += points; // Aumenta la puntuación
        FindObjectOfType<TextManager>().UpdateScoreText(); // Actualiza el texto de la puntuación

        if (highScore <= score)
        {
            highScore = score;
            FindObjectOfType<TextManager>().UpdateHighScoreText();
        }
    
    }


    //void UpdateLivesText()
    //{
    //    livesText.text = "Lives: " + lives; // Actualiza el texto del UI
    //}

    //void UpdateScoreText()
    //{
    //    scoreText.text = "Score: " + score; // Actualiza el texto de la puntuación
    //}

    //void UpdateHighScoreText()
    //{
    //    highScoreText.text = "High Score: " + highScore; // Actualiza el texto de la puntuación
    //}

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        // Aquí puedes agregar lógica para finalizar el juego (reiniciar, mostrar pantalla de Game Over, etc.)
    }

    private void LoadNextLevel()
    {
        if(sceneName == "Lvl1")
        {
            SceneManager.LoadScene("Lvl2");
        }
        else if(sceneName == "Lvl2")
        {
            SceneManager.LoadScene("Lvl1");
        }
        
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
