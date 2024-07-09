using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    void LateUpdate()
    {
        // Mantener la posición de la cámara del mini mapa directamente encima del jugador
        Vector3 newPosition = playerTransform.position;
        newPosition.y = transform.position.y; // Mantener la altura de la cámara
        transform.position = newPosition;

        // Opcional: mantener la rotación fija para que siempre apunte hacia abajo
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}