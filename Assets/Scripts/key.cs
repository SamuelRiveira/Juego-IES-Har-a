using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject player; // Asigna el objeto que tiene el FirstPersonController
    public GameObject altCamera; // Cámara alternativa a activar
    public GameObject zoneCanvas; // Canvas que aparece al entrar en la zona
    public GameObject secondCanvas; // Canvas que se activa al presionar "E"

    private FirstPersonController playerController; 
    private bool isInsideZone = false;
    private bool isInteracting = false;

    void Start()
    {
        // Inicializamos el controller del jugador
        playerController = player.GetComponent<FirstPersonController>();

        // Desactivamos los canvas que no deben aparecer al principio
        if (zoneCanvas) zoneCanvas.SetActive(false);
        if (secondCanvas) secondCanvas.SetActive(false);
        if (altCamera) altCamera.SetActive(false);
    }

    void Update()
    {
        // Si estamos dentro de la zona y no estamos interactuando
        if (isInsideZone && !isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterInteractionMode(); // Llamar a la función para activar el segundo Canvas
            }
        }
        // Si estamos interactuando y presionamos "ESC"
        else if (isInteracting && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInteractionMode(); // Volver al estado normal
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isInsideZone = true;
            if (zoneCanvas) zoneCanvas.SetActive(true); // Muestra el canvas de zona al entrar
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInsideZone = false;
            if (zoneCanvas) zoneCanvas.SetActive(false); // Oculta el canvas de zona al salir
        }
    }

    void EnterInteractionMode()
    {
        isInteracting = true;
        playerController.enabled = false; // Desactivar el controlador de jugador
        if (altCamera) altCamera.SetActive(true); // Activar la cámara alternativa
        if (zoneCanvas) zoneCanvas.SetActive(false); // Ocultar el primer Canvas
        if (secondCanvas) secondCanvas.SetActive(true); // Activar el segundo Canvas
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor
        Cursor.visible = true; // Hacer visible el cursor
    }

    void ExitInteractionMode()
    {
        isInteracting = false;
        playerController.enabled = true; // Reactivar el controlador de jugador
        if (altCamera) altCamera.SetActive(false); // Desactivar la cámara alternativa
        if (zoneCanvas) zoneCanvas.SetActive(false); // Asegurarse de que el primer Canvas esté oculto
        if (secondCanvas) secondCanvas.SetActive(false); // Ocultar el segundo Canvas
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor
        Cursor.visible = false; // Hacer invisible el cursor
    }
}
