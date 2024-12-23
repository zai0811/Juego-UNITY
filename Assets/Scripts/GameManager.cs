using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerLives = 3; // Vidas del jugador
    public Text livesText; // UI para mostrar vidas
    public GameObject gameOverPanel; // Panel de Game Over

    private void Awake()
    {
        // Asegurar una única instancia del GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateLivesUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void PlayerTakeDamage()
    {
        playerLives--; // Restar una vida
        UpdateLivesUI();

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Vidas: " + playerLives; // Actualizar UI
    }

    private void GameOver()
    {
        Time.timeScale = 0f; // Detener el tiempo
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); // Mostrar el panel de Game Over
    }
}
