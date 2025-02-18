using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarLuz : MonoBehaviour
{
    public GameObject luzUI; // Canvas
    public GameObject numeroUI; // Número
    public GameObject luz; // GameObject que representa la luz
    public GameObject lamparas;
    public AudioSource sonidoLuz; // AudioSource para el sonido

    private bool enZona = false; // ¿Está el jugador dentro de la zona?

    void Start()
    {
        luzUI.SetActive(false); // Inicialmente no mostrar el canvas
        numeroUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lamparas.SetActive(false);
        sonidoLuz.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true; // El jugador entra en la zona
            luzUI.SetActive(true); // Muestra el canvas de la luz
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false; // El jugador sale de la zona
            luzUI.SetActive(false); // Oculta el canvas de la luz
        }
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E)) // Si está en la zona y se presiona la tecla "E"
        {
            bool luzActiva = luz.activeSelf; // Verifica si el GameObject de la luz está activo
            luz.SetActive(!luzActiva); // Activa o desactiva la luz
            lamparas.SetActive(luzActiva);

            numeroUI.SetActive(luzActiva); // Muestra el número si la luz está apagada

            if (sonidoLuz != null) // Verifica si hay un AudioSource asignado
            {
                sonidoLuz.Play(); // Reproduce el sonido
            }
        }
    }
}
