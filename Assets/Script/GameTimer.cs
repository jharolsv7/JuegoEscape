using UnityEngine;
using UnityEngine.SceneManagement; // Manejar escenas
using TMPro; // Espacio de nombres para TextMeshPro

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // 1 minuto
    public TextMeshProUGUI timerText; // Cambiado a TextMeshPro
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    private float currentTime;

    void Start()
    {
        currentTime = totalTime;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (currentTime <= 0)
        {
            GameOver();
        }

        // Verificar si se presiona la tecla R para reiniciar el juego
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Victory()
    {
        Time.timeScale = 0f;

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
        else
        {
            Debug.Log("¡Has ganado!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
