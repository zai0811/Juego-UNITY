using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica si es el jugador
        {
            PlayerMoveJoystick player = collision.GetComponent<PlayerMoveJoystick>();
            if (player != null)
            {
                player.LevelUp(); // Llama al método LevelUp() del jugador
            }
        }
    }
}

