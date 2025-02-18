using UnityEngine;
using UnityEngine.UI;

public class CodeChecker : MonoBehaviour
{
    [Header("InputField para introducir el código")]
    public InputField codeInputField;

    [Header("Objetos de interacción")]
    public GameObject escapaObject;           // Objeto que se activará
    public GameObject accederKeypad;          // Objeto que se desactivará
    public GameObject completarPuzles;        // Objeto que se desactivará
    public GameObject LeerLibro;        // Objeto que se desactivará
    public GameObject escapaDeLaClase;        // Objeto que se activará

    [Header("Referencias para restaurar el estado de la interacción")]
    public GameObject player;                 // Jugador que se reactiva
    public Camera sceneCamera;                // Cámara de interacción a desactivar
    public GameObject sceneCanvas;            // Canvas de interacción a desactivar

    // Código esperado (en formato string)
    private string expectedCode = "572392689";

    // Este método se asigna al botón para comprobar el código
    public void CheckCode()
    {
        if (codeInputField == null)
        {
            Debug.LogWarning("No se ha asignado el InputField en el Inspector.");
            return;
        }

        string enteredCode = codeInputField.text;

        if (enteredCode == expectedCode)
        {
            // Restaurar el estado de la interacción para que el jugador pueda salir
            if (player != null)
            {
                player.SetActive(true);
                Debug.Log("Jugador reactivado.");
            }
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
                Debug.Log("Cámara de interacción desactivada.");
            }
            if (sceneCanvas != null)
            {
                sceneCanvas.SetActive(false);
                Debug.Log("Canvas de interacción desactivado.");
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Activar los objetos Escapa y EscapaDeLaClase
            if (escapaObject != null)
            {
                escapaObject.SetActive(true);
                Debug.Log("Objeto 'Escapa' activado.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto 'Escapa' en el Inspector.");
            }
            if (escapaDeLaClase != null)
            {
                escapaDeLaClase.SetActive(true);
                Debug.Log("Objeto 'EscapaDeLaClase' activado.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto 'EscapaDeLaClase' en el Inspector.");
            }

            // Desactivar los objetos AccederKeypad, completarPuzles y LeerLibro
            if (accederKeypad != null)
            {
                accederKeypad.SetActive(false);
                Debug.Log("Objeto 'AccederKeypad' desactivado.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto 'AccederKeypad' en el Inspector.");
            }
            if (completarPuzles != null && LeerLibro != null)
            {
                completarPuzles.SetActive(false);
                LeerLibro.SetActive(false);
                Debug.Log("Objeto 'completarPuzles' desactivado.");
                Debug.Log("Objeto 'LeerLibro' desactivado.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto 'completarPuzles' en el Inspector.");
            }
        }
        else
        {
            Debug.Log("Código incorrecto.");
        }
    }
}
