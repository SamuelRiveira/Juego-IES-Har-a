using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccederLibro : MonoBehaviour
{
    public GameObject CanvaLibro; // Canvas de la pizarra
    public GameObject Libro; // Cámara de la pizarra
    public GameObject firstPersonController; // FPS Controller
    public GameObject textoLeer;
    public GameObject textoPuzles;

    private bool enZona = false;
    private bool enPizarra = false;
    private bool primeraLectura = false;

    void Start()
    {
        CanvaLibro.SetActive(false);
        Libro.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true;
            CanvaLibro.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false;
            CanvaLibro.SetActive(false);

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
            primeraLectura = true;
            if(primeraLectura)
            {
                textoLeer.SetActive(false);
                textoPuzles.SetActive(true);
            }
            firstPersonController.SetActive(false);
            Libro.SetActive(true);

            // Mostrar y desbloquear el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            firstPersonController.SetActive(true);
            Libro.SetActive(false);

            // Ocultar y bloquear el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
