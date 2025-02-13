using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escapar : MonoBehaviour
{
    public GameObject escapar;

    public void ActivateEscape()
    {
        GameObject textoPuzles = GameObject.Find("CompletarPuzzles");

        if (textoPuzles != null)
            textoPuzles.SetActive(false);

        escapar.SetActive(true);
    }
}
