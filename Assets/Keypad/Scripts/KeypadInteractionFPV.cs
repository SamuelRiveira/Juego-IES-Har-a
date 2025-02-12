using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad
{
    public class KeypadInteractionFPV : MonoBehaviour
    {
        private Camera cam;
        private void Awake() => cam = Camera.main;

        private void Update()
        {
            // Crear un ray que salga desde el centro de la pantalla (el crosshair)
            var centerScreenPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = cam.ScreenPointToRay(centerScreenPoint);

            if (Input.GetMouseButtonDown(0)) // Verificar si el botón izquierdo del ratón es presionado
            {
                if (Physics.Raycast(ray, out var hit))
                {
                    // Si el raycast colisiona con un KeypadButton
                    if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                    {
                        keypadButton.PressButton();
                    }
                }
            }
        }
    }
}
