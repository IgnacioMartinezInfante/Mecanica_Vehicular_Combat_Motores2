using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocultar_Cursor : MonoBehaviour
{
    void Start()
    {
        // Ocultar el cursor
        Cursor.visible = false;

        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Opcional: Mostrar el cursor y desbloquearlo al presionar Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
