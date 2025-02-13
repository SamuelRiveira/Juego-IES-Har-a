using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class Escape : MonoBehaviour
{
    public GameObject CanvaEscapar;

    private bool enZona = false;

    void Start()
    {
        CanvaEscapar.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true;
            CanvaEscapar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false;
            CanvaEscapar.SetActive(false);
        }
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            ActivarCursorYEscena();
        }
    }

    void ActivarCursorYEscena()
    {
        // Mostrar y desbloquear el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Cambiar de escena
        SceneManager.LoadScene("Pantalla Final");
    }
}
