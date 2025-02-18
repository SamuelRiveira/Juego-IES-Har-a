using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarRadio : MonoBehaviour
{
    public GameObject radioUI; // Canvas
    public AudioSource sonido; // Sonido a reproducir

    private bool enZona = false; // ¿Está el jugador dentro de la zona?

    void Start()
    {
        radioUI.SetActive(false); // Inicialmente no mostrar el canvas
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sonido.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true; // El jugador entra en la zona
            radioUI.SetActive(true); // Muestra el canvas
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false; // El jugador sale de la zona
            radioUI.SetActive(false); // Oculta el canvas
        }
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E)) // Si está en la zona y se presiona la tecla "E"
        {
            if (!sonido.isPlaying)
            {
                sonido.Play(); // Reproduce el sonido si no se está reproduciendo
            }
        }
    }
}