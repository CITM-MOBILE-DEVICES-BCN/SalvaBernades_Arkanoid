using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLivesText()
    {
        livesText.text = "Lives: " + FindObjectOfType<GameManager>().lives; // Actualiza el texto del UI
    }
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + FindObjectOfType<GameManager>().score; // Actualiza el texto de la puntuación
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + FindObjectOfType<GameManager>().highScore; // Actualiza el texto de la puntuación
    }
}
