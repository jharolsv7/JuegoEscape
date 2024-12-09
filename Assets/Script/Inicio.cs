using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar escenas

public class MenuInicio : MonoBehaviour
{
    public GameObject menuPanel; // Panel del menú de inicio

    private bool gameStarted = false; // Bandera para verificar si el juego ya empezó

    void Start()
    {
        // Asegurarse de que el menú esté activo al iniciar
        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
        }

        Time.timeScale = 0f; // Pausar el juego
    }

    void Update()
    {
        // Si el juego no ha empezado y se presiona la tecla X
        if (!gameStarted && Input.GetKeyDown(KeyCode.X))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;

        // Desactivar el menú
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        Time.timeScale = 1f; // Reanudar el juego
    }
}
