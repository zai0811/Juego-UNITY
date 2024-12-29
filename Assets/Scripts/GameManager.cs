using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Funcionalidad del mapa
    public float velocidad = 2;
    public Renderer bg;
    public GameObject col1;
    public GameObject piedra1;
    public GameObject piedra2;
    public List<GameObject> suelo;
    public List<GameObject> obstaculos;

    // Funcionalidad del jugador
    public int playerLives = 3; // Vidas del jugador
    public Text livesText; // UI para mostrar vidas
    public GameObject menuInicio;
    public GameObject menuGameOver;
    public GameObject gameOverPanel; // Panel de Game Over

    public bool start = false;
    public bool gameOver = false;

    private void Awake()
    {
        // Asegurar una única instancia del GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Crear mapa
        for (int i = 0; i < 21; i++)
        {
            suelo.Add(Instantiate(col1, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        obstaculos.Add(Instantiate(piedra1, new Vector2(15, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(20, -2), Quaternion.identity));

        // Configurar UI inicial
        UpdateLivesUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (!start && !gameOver)
        {
            menuInicio.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        else if (gameOver)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            menuInicio.SetActive(false);
            menuGameOver.SetActive(false);

            // Mover BG
            bg.material.mainTextureOffset = bg.material.mainTextureOffset + new Vector2(0.015f, 0) * velocidad * Time.deltaTime;

            // Mover mapa
            for (int i = 0; i < suelo.Count; i++)
            {
                if (suelo[i].transform.position.x <= -10)
                {
                    suelo[i].transform.position = new Vector3(10f, -3, 0);
                }
                suelo[i].transform.position = suelo[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            }

            // Mover obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(10, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            }
        }
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
            livesText.text = "Vidas: " + playerLives;
    }

    private void GameOver()
    {
 Time.timeScale = 1f; // Asegúrate de que el tiempo esté activo
  playerLives = 3; // Reinicia las vidas
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga automáticamente el nivel actual
}}
