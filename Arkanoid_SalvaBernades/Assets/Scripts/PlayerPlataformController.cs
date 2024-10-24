using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class PlayerPlatformController : MonoBehaviour
{
    public Slider movementSlider; // El Slider que controla el movimiento
    public float platformYPosition = -4f; // Posici�n fija en Y (ajusta seg�n la altura de tu plataforma)
    public float movementSpeed = 10f; // Velocidad de movimiento (opcional para suavizar el movimiento)

    void Update()
    {
        // Actualizar la posici�n de la plataforma en funci�n del valor del Slider
        float sliderValue = movementSlider.value;

        // Mover la plataforma solo en el eje X usando el valor del Slider
        Vector2 newPosition = new Vector2(sliderValue, platformYPosition);

        // Actualizamos la posici�n de la plataforma (puedes a�adir movimiento suave con Lerp si lo prefieres)
        transform.position = newPosition;
    }
}
