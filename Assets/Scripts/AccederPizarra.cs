using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccederPizarra : MonoBehaviour
{
    public GameObject pizarraUI; // Canvas de la pizarra
    public GameObject cameraPizarra; // Cámara de la pizarra
    public GameObject firstPersonController; // FPS Controller

    private bool enZona = false;
    private bool enPizarra = false;

    void Start()
    {
        pizarraUI.SetActive(false);
        cameraPizarra.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true;
            pizarraUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false;
            pizarraUI.SetActive(false);

            if (enPizarra)
            {
                CambiarModo();
            }
        }
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            CambiarModo();
        }

        if (enPizarra && Input.GetKeyDown(KeyCode.Escape))
        {
            CambiarModo();
        }
    }

    void CambiarModo()
    {
        enPizarra = !enPizarra;

        if (enPizarra)
        {
            firstPersonController.SetActive(false);
            cameraPizarra.SetActive(true);

            // Mostrar y desbloquear el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            firstPersonController.SetActive(true);
            cameraPizarra.SetActive(false);

            // Ocultar y bloquear el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
