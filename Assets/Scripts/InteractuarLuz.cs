using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarLuz : MonoBehaviour
{
    public GameObject luzUI; // Canvas
    public Light luz; // Luz

    private bool enZona = false; // ¿Está el jugador dentro de la zona?

    void Start()
    {
        luzUI.SetActive(false); // Inicialmente no mostrar el canvas
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            luz.enabled = !luz.enabled; // Alterna el estado de la luz
        }
    }
}
