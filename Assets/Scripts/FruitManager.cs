using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;

<<<<<<< HEAD
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
=======
    public Text totalFruits;
    public Text fruitsCollected;
    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
        
>>>>>>> parent of 6a1adc1 (avanza de nivel cuando accede a la puerta)
    }

    private void Update()
    {
<<<<<<< HEAD
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
=======
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
>>>>>>> parent of 6a1adc1 (avanza de nivel cuando accede a la puerta)
    }
    public void AllFruitsCollected()
    {
<<<<<<< HEAD
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
=======
        if(transform.childCount == 0)
        {
            Debug.Log("No quedan frutas");
            //levelCleared.gameObject.SetActive(true);
            transition.gameObject.SetActive(true);
            Invoke("ChangeScene", 1);
>>>>>>> parent of 6a1adc1 (avanza de nivel cuando accede a la puerta)
        }
    }

    /// <summary>
    /// Cambia la escena actual por la siguiente en la lista de escenas cargadas
    /// Si la escena actual es la última, vuelve a la primera escena.
    /// </summary>
    void ChangeScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }
<<<<<<< HEAD
        if (collectedFruits >= totalFruitsInLevel && Input.GetKey("e"))
=======
        else
>>>>>>> parent of 6a1adc1 (avanza de nivel cuando accede a la puerta)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
