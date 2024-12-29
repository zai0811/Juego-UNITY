using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public GameObject menuUI; // Asignar el menú con los botones en el inspector

    void Update()
    {
        // Iniciar el juego al presionar la tecla X en la escena de inicio
        if (SceneManager.GetActiveScene().name == "Inicio" && Input.GetKeyDown(KeyCode.X))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Inicio"); // Inicio del juego
        SceneManager.LoadScene("Level1"); // Cambia a la escena del Nivel 1
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu"); // Redirige a la escena del menú si pierdes
    }

    public void GameWin()
    {
        SceneManager.LoadScene("Menu"); // Redirige al menú si ganas el juego
        ShowMenu(); // Activa el menú con los botones
    }

    public void ShowMenu()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(true); // Muestra el menú
        }
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra el juego (solo funciona en builds)
    }
}

