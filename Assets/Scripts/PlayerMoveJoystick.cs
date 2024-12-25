using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar niveles y escenas
using UnityEngine.UI; // Para mostrar mensajes

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;
    public float runSpeedHorizontal = 2;
    public float runSpeed = 1.25f;

    // Configuración de salto
    public float baseJumpSpeed = 3; // Altura de salto base
    public float jumpSpeed; // Se incrementa en cada nivel
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    private Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private int currentLevel = 0; // Nivel actual
    public Text endGameText; // Texto de finalización (debe asignarse en el Inspector)
    public GameObject endGamePanel; // Panel de finalización del juego

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jumpSpeed = baseJumpSpeed; // Inicializa la altura del salto
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false); // Ocultar el panel al inicio
        }
    }

    private void Update()
    {
        // Movimiento horizontal con teclas A y D
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = -runSpeedHorizontal;
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = runSpeedHorizontal;
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else
        {
            horizontalMove = 0;
            animator.SetBool("Run", false);
        }

        // Salto con tecla B
        if (Input.GetKeyDown(KeyCode.B))
        {
            Jump();
        }

        // Animaciones de caída
        if (rb2D.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.linearVelocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimiento horizontal
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
        }
        else if (canDoubleJump)
        {
            animator.SetBool("DoubleJump", true);
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed);
            canDoubleJump = false;
        }
    }

    // Incrementa la altura del salto en cada nivel
    public void LevelUp()
    {
        currentLevel++;
        jumpSpeed = baseJumpSpeed + (0.5f * currentLevel); // Incremento progresivo

         if (currentLevel == 3)
    {
        // Cargar la escena usando su nombre o Build Index
        SceneManager.LoadScene("Fin", LoadSceneMode.Single);
    }
    }

   
}
