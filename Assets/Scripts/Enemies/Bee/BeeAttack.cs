using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;
    public float distanceRaycast = 0.5f;
    private float coolDownAttack = 1.5f;
    private float actualCoolDownAttack;

    public GameObject beeBullet;

    // Start is called before the first frame update
    void Start()
    {
        actualCoolDownAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualCoolDownAttack -= Time.deltaTime;
        //Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        if(hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if(actualCoolDownAttack < 0)
                {
                    Invoke("LaunchBullet", 0.5f);
                    animator.Play("Attack");
                    actualCoolDownAttack = coolDownAttack;
                }
            }
        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
