using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Referencia al menú de pausa (Canvas o Panel)
    public GameObject MenuPausa, Camera;

    // Referencia a la cámara principal
    public Camera mainCamera;

    // Variables para congelar la cámara
    private Quaternion cameraRotationAtPause; // Rotación de la cámara cuando está pausada

    // Estado del juego
    private bool isPaused = false;

    public Slider volumeSlider; // Referencia al Slider

    //private bool oneTime = false;

    void Start()
    {
        MenuPausa.SetActive(false);

        // Inicializar el valor del Slider al volumen actual
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;

            // Suscribir el método para cambiar el volumen cuando se mueva el Slider
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    void Update()
    {
        // Detecta si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Reanudar el juego
            }
            else
            {
                PauseGame(); // Pausar el juego
            }
        }
    }

    // Método para cambiar el volumen
    public void ChangeVolume(float value)
    {
        // Cambiar el volumen global del juego
        AudioListener.volume = value;
    }

    // Método para pausar el juego
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None; //Que se pueda mover el raton por el menu
        Cursor.visible = true; //Hacer visible el raton
        MenuPausa.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true; // Marca el estado del juego como pausado

        // Guardar la posición y rotación actuales de la cámara
        //cameraPositionAtPause = mainCamera.transform.position;
        cameraRotationAtPause = mainCamera.transform.rotation;

        // Congelar la cámara (mantener su posición y rotación)
        FreezeCamera();
    }

    private void FreezeCamera()
    {
        mainCamera.transform.rotation = cameraRotationAtPause;

    }

    // Método para reanudar el juego
    public void ResumeGame()
    {
        Debug.Log("Vuelves");
        //oneTime = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenuPausa.SetActive(false); // Oculta el me    
        Time.timeScale = 1f; // Detiene el tiempo del juego
        isPaused = false; // Marca el estado del juego como pausado
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}