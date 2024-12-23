using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Text text; // Asignado en el Inspector
    public string levelName;
    private bool inDoor = false;

    private float doorTime = 2.5f;
    private float startTime = 2.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (text != null)
            {
                text.gameObject.SetActive(true); // Muestra el texto
            }
            else
            {
                Debug.LogError("El objeto Text no está asignado.");
            }
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (text != null)
        {
            text.gameObject.SetActive(false); // Oculta el texto
        }
        inDoor = false;
        doorTime = startTime; // Reinicia el temporizador
    }

    private void Update()
    {
        if (text == null)
        {
            Debug.LogError("El objeto Text fue destruido o no está asignado.");
            return; // Evita errores adicionales
        }

        if (inDoor)
        {
            doorTime -= Time.deltaTime;
        }



        if (doorTime <= 0  && Input.GetKey("e") && AllFruitsCollected())
        {
            SceneManager.LoadScene(levelName);
        }
    }

    private bool AllFruitsCollected()
    {
        return FindObjectOfType<FruitManager>().transform.childCount == 0;
    }
}
