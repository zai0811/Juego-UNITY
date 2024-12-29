using UnityEngine;


using UnityEngine.SceneManagement;

public class OptionsButtonsManager : MonoBehaviour
{
    // Función para volver al juego (cerrar el panel de opciones)
    public GameObject panelOptions;
    // Función para alternar el estado del panel
    public void ToggleOptionsPanel()
    {
        if (panelOptions != null)
        {
            bool isActive = panelOptions.activeSelf;
            panelOptions.SetActive(!isActive); // Alternar entre activo y desactivado

            // Pausar o reanudar el juego dependiendo del estado del panel
            Time.timeScale = isActive ? 1f : 0f; // 1 = Reanudar, 0 = Pausar
        }
    }
    public void ResumeGame()
    {
        if (panelOptions != null)
        {
            panelOptions.SetActive(false); // Desactiva el panel de opciones
            Time.timeScale = 1f; // Reanuda el tiempo
        }
    }

    // Función para reiniciar el nivel actual
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Asegura que el tiempo esté corriendo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }

    // Función para ir al menú de inicio
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo esté corriendo
        SceneManager.LoadScene("Inicio"); // Carga la escena del menú principal
    }

    // Función para salir del juego
    public void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
    #else
        Application.Quit(); // Cierra la aplicación en la compilación
    #endif
            Debug.Log("Saliendo del juego...");

    }
}

