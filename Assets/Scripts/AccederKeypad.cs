using UnityEngine;

public class AccederKeypad : MonoBehaviour
{
    [Header("Referencias de UI y Cámara")]
    public GameObject promptCanvas;   // Canvas que aparece al entrar en la zona (ej. mensaje "Pulsa E")
    public GameObject sceneCanvas;    // Canvas que se activa en la interacción
    public Camera sceneCamera;        // Cámara que se activa en la interacción

    [Header("Referencia al Jugador")]
    public GameObject player;         // Jugador a desactivar/activar

    // Variables de control
    private bool playerInZone = false;      // Indica si el jugador está en la zona
    private bool interactionActive = false; // Indica si ya se inició la interacción

    // Se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (promptCanvas != null)
            {
                promptCanvas.SetActive(true);
            }
        }
    }

    // Se llama cuando otro collider sale del trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            if (promptCanvas != null)
            {
                promptCanvas.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Si el jugador está en la zona y aún no se ha iniciado la interacción
        if (playerInZone && !interactionActive)
        {
            // Al pulsar la tecla E
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionActive = true;

                // Ocultamos el prompt si está activo
                if (promptCanvas != null)
                    promptCanvas.SetActive(false);

                // Desactivamos el jugador
                if (player != null)
                    player.SetActive(false);

                // Activamos la cámara de interacción
                if (sceneCamera != null)
                    sceneCamera.gameObject.SetActive(true);

                // Activamos el canvas de interacción
                if (sceneCanvas != null)
                    sceneCanvas.SetActive(true);

                // Mostramos y liberamos el cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        // Durante la interacción, si se pulsa ESC se vuelve al estado inicial
        if (interactionActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                interactionActive = false;

                // Reactivamos el jugador
                if (player != null)
                    player.SetActive(true);

                // Desactivamos la cámara de interacción
                if (sceneCamera != null)
                    sceneCamera.gameObject.SetActive(false);

                // Desactivamos el canvas de interacción
                if (sceneCanvas != null)
                    sceneCanvas.SetActive(false);

                // Vuelve a bloquear el cursor (dependiendo de tu configuración inicial)
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
