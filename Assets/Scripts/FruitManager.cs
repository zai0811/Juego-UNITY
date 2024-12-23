using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;

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
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
    }
    public void AllFruitsCollected()
    {

        if(transform.childCount == 0)
        {
            Debug.Log("No quedan frutas");
            //levelCleared.gameObject.SetActive(true);
            transition.gameObject.SetActive(true);
            Invoke("ChangeScene", 1);
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

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
