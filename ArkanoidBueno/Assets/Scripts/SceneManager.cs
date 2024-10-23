using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir esta línea para trabajar con escenas

public class MenuManager : MonoBehaviour
{
    // Método para cargar la escena
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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
