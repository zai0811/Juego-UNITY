using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI; // Necesario para manejar UI
public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    private float checkPointPositionX, checkPointPositionY;
    public Animator animator;
  // Nuevo: Referencias al GameOverPanel y GameOverText
    public GameObject gameOverPanel;

    public Text gameOverText;
    private void Start()
    {
        life = hearts.Length;

        if(PlayerPrefs.GetFloat("checkPointPositionX") != 0){
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife()
    {
        if(life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
                        // Mostrar el Game Over Panel
            GameOver();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");

        }
        else if(life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");

        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    }

    // Nuevo: Método para manejar el Game Over
    private void GameOver()
    {
        if (gameOverPanel != null && gameOverText != null)
        {
            gameOverPanel.SetActive(true); // Mostrar el panel de Game Over
            gameOverText.text = "Perdiste el Juego!!"; // Actualizar el texto
            Time.timeScale = 0f; // Detener el juego
            Debug.Log("Perdiste el Juego!!");
        }

    }
}
