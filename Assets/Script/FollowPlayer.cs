using UnityEngine;

public class FolloePlayer : MonoBehaviour
{
    // Referencia al transform del jugador
    public Transform player;

    // Offset para ajustar la posición de la cámara
    public Vector3 offset = new Vector3(0, 5, -10);

    // Velocidad de suavizado del movimiento de la cámara
    public float smoothSpeed = 0.001f;

    void LateUpdate()
    {
        // Calcular la posición deseada de la cámara
        Vector3 desiredPosition = player.position + offset;

        // Interpolar suavemente entre la posición actual y la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Establecer la posición de la cámara
        transform.position = smoothedPosition;

        // Opcionalmente, hacer que la cámara mire al jugador
        transform.LookAt(player);
    }
}