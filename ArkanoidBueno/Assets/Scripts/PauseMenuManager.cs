using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas
using UnityEngine.UI; // Para el manejo del UI

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // El panel del menú de pausa
    private bool isPaused = false; // Variable para rastrear si el juego está pausado

    void Update()
    {
        // Si se presiona la tecla Escape, alternamos el estado de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Función para reanudar el juego
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Restablece el tiempo del juego
        isPaused = false; // Indica que el juego ya no está pausado
    }

    // Función para pausar el juego
    void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true; // Indica que el juego está pausado
    }

    // Función para salir al menú principal
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Restablece el tiempo para que el juego no siga pausado
        SceneManager.LoadScene("Main Menu"); // Cambia a la escena del menú principal (asegúrate de que el nombre sea correcto)
    }

    // Función para salir del juego
    public void QuitGame()
    {
        // Si estamos en el editor, detener la reproducción
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Esto solo funciona en el editor
#else
        Application.Quit(); // Cierra el juego en una compilación
#endif
    }
}
