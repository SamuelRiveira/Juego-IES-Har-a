using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class Escape : MonoBehaviour
{
    public GameObject CanvaEscapar;
    public AudioSource sonidoEscape; // AudioSource para el sonido

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
        // Reproducir el sonido
        if (sonidoEscape != null)
        {
            sonidoEscape.Play(); // Reproduce el sonido
        }

        // Mostrar y desbloquear el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Cambiar de escena después de un pequeño retraso para que se escuche el sonido
        StartCoroutine(CambiarEscenaConRetardo());
    }

    IEnumerator CambiarEscenaConRetardo()
    {
        // Espera unos segundos antes de cambiar la escena para escuchar el sonido
        yield return new WaitForSeconds(sonidoEscape.clip.length);

        // Cambiar de escena
        SceneManager.LoadScene("Pantalla Final");
    }
}
