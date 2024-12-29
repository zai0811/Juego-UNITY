using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        // Detectar la tecla X
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadLevel1();
        }
    }

    void LoadLevel1()
    {
        // Cambiar a la escena del nivel 1
        SceneManager.LoadScene("Level1");
    }
}
