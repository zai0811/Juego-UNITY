using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameManager gameManager;
    public float fuerzaSalto;
    public float velocidadMovimiento = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameManager.start && !gameManager.gameOver)
        {
            // Movimiento Horizontal
            float horizontalInput = Input.GetAxis("Horizontal"); // Flechas Izquierda/Derecha o A/D
            float verticalInput = Input.GetAxis("Vertical");     // Flechas Arriba/Abajo o W/S

            Vector2 movement = new Vector2(horizontalInput * velocidadMovimiento, rb.linearVelocity.y);

            // Movimiento Vertical cuando no hay gravedad
            if (Mathf.Approximately(rb.gravityScale, 0))
            {
                movement.y = verticalInput * velocidadMovimiento;
            }

            rb.linearVelocity = movement;

            // Salto
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (IsGrounded())
                {
                    anim.SetBool("estaSaltando", true);
                    rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
                }
            }
        }

        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            anim.SetBool("estaSaltando", false);
        }

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            gameManager.gameOver = true;
        }
    }

    private bool IsGrounded()
    {
        // Verifica si el jugador está tocando el suelo
        return rb.linearVelocity.y == 0;
    }
}
