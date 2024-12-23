using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D collider2D;
    public Animator animator;
    public GameObject swordParent;

    //public GameObject attackButton;

    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        //if(Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }

        if(playerSpriteRenderer.flipX == true)
        {
            swordParent.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Attack()
    {
        animator.Play("Attack");
        collider2D.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }

    public void DisableAttack()
    {
        collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<JumpDamage>().LosseLifeAndHit();
            collider2D.enabled = false;

        }
    }

    
}
