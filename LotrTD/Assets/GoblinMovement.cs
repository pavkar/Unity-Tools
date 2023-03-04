using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;

    private float time = 0f;
    private bool isNextToWall = false;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement.x = 0;
        movement.y = -1;
        animator.SetBool("walkEnabled", false);
        time = Time.time;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        animator.SetBool("walkEnabled", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isNextToWall == false)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            /*
            if (time + 5 < Time.time)
            {
                time = Time.time;
            }
            else if (time + 2 < Time.time)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                animator.SetBool("walkEnabled", true);
            }
            else
            {
                animator.SetBool("walkEnabled", false);
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("goblin on trigger enter");
        if (collision.gameObject.GetComponent<Wall>())
        {
            Debug.Log("Goblin trigger wall");
            isNextToWall = true;
            animator.SetBool("walkEnabled", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Goblin collision");
    }
}