using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Empezar : MonoBehaviour, IPointerClickHandler
{
    public string escena; // Nombre de la escena a cargar

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(escena);
    }
}
