using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTexto : MonoBehaviour
{
    public GameObject textoPuzles;    // Asignar desde el Inspector
    public GameObject textoEscapar;   // Asignar desde el Inspector
    public GameObject textoLibro;     // Asignar desde el Inspector

    void Update()
    {
        // Si textoPuzles y textoLibro están desactivados, activamos textoEscapar
        if (textoPuzles != null && !textoPuzles.activeSelf &&
            textoLibro != null && !textoLibro.activeSelf)
        {
            textoEscapar.SetActive(true);
        }
        else
        {
            textoEscapar.SetActive(false);
        }
    }
}
