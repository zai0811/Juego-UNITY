using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared; // Texto para indicar que el nivel ha sido completado
    public GameObject transition; // Objeto de transición entre niveles

    public Text totalFruits; // Texto para mostrar el total de frutas en el nivel
    public Text fruitsCollected; // Texto para mostrar las frutas recolectadas
    private int totalFruitsInLevel; // Total de frutas en el nivel
    private int collectedFruits = 0; // Frutas recolectadas

    private void Start()
    {
        totalFruitsInLevel = transform.childCount; // Contar el número de frutas en el nivel
        if (totalFruits != null)
        {
            totalFruits.text = totalFruitsInLevel.ToString(); // Actualizar el texto del total de frutas
        }
        if (fruitsCollected != null)
        {
            fruitsCollected.text = collectedFruits.ToString(); // Inicializar el texto de frutas recolectadas
        }
    }

    private void Update()
    {
        // Actualizar el texto de frutas recolectadas
        if (fruitsCollected != null)
        {
            fruitsCollected.text = collectedFruits.ToString();
        }
        AllFruitsCollected(); // Verificar si todas las frutas han sido recolectadas
    }

    public void CollectFruit()
    {
        collectedFruits++; // Incrementar el contador de frutas recolectadas
        if (collectedFruits >= totalFruitsInLevel)
        {
            AllFruitsCollected();
        }
    }

    public void AllFruitsCollected()
    {
        if (collectedFruits >= totalFruitsInLevel)
        {
            Debug.Log("No quedan ");
            // Mostrar mensaje de todas las frutas recolectadas
            if (levelCleared != null)
            {
                levelCleared.gameObject.SetActive(true);
                levelCleared.text = "¡Has recolectado todas !";
            }
            //transition.gameObject.SetActive(true); // Mostrar la transición
            // Invoke("ChangeScene", 1); // Cambiar de escena después de 1 segundo
        }
    }

    /// <summary>
    /// Cambia la escena actual por la siguiente en la lista de escenas cargadas
    /// Si la escena actual es la última, vuelve a la primera escena.
    /// </summary>
    void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0); // Volver a la primera escena si es la última
        }
        if (collectedFruits >= totalFruitsInLevel && Input.GetKey("e"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cargar la siguiente escena
        }
    }
}
