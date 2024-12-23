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

    private void Start()
    {
        totalFruitsInLevel = transform.childCount; // Contar el número de frutas en el nivel
    }

    private void Update()
    {
        AllFruitsCollected(); // Verificar si todas las frutas han sido recolectadas
        totalFruits.text = totalFruitsInLevel.ToString(); // Actualizar el texto del total de frutas
        fruitsCollected.text = transform.childCount.ToString(); // Actualizar el texto de frutas recolectadas
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas");
            //transition.gameObject.SetActive(true); // Mostrar la transición
           // Invoke("ChangeScene", 1); // Cambiar de escena después de 1 segundo
        }
    }

    void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0); // Volver a la primera escena si es la última
        }
       if ((fruitsCollected.transform.childCount == 0) && Input.GetKey("e") )
        
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cargar la siguiente escena
        }
    }
}
