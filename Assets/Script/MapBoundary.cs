using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    // Límites del mapa en 2D
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;

    void LateUpdate()
    {
        // Obtener la posición actual
        Vector3 position = transform.position;

        // Restringir movimiento en X
        position.x = Mathf.Clamp(position.x, minX, maxX);

        // Restringir movimiento en Y
        position.y = Mathf.Clamp(position.y, minY, maxY);

        // Actualizar posición
        transform.position = position;
    }

    // Método para visualizar los límites en el editor
    void OnDrawGizmosSelected()
    {
        // Dibujar un cubo que representa los límites del mapa
        Gizmos.color = Color.red;
        Vector3 center = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, 0);
        Vector3 size = new Vector3(maxX - minX, maxY - minY, 1);
        Gizmos.DrawWireCube(center, size);
    }
}