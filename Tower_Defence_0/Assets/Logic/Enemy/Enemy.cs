using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigidBody;

    [SerializeField] protected int health;
    [SerializeField] protected int damage;

    [SerializeField] protected float speedX;
    [SerializeField] protected float speedY;

    protected Vector3 size = new Vector3(1, 1, 0);

    protected Collider enemyCollider;
    protected BoxCollider2D boxCollider;
    protected Rigidbody enemyRigidbody;
    protected Enemy()
    {
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();

        if (rigidBody != null)
        {
            rigidBody.gravityScale = 0;
        }
        else
        {
            Debug.LogWarning("No RigidBody");
        }

        if (spriteRenderer != null && boxCollider != null)
        {
            this.transform.localScale = size;
            this.spriteRenderer.sortingOrder = 10;
            this.boxCollider.size = new Vector3(0.5f, 0.5f, 0);
        }
        else
        {
            Debug.LogWarning("No SpriteRenderer");
        }
    }

    private void Start()
    {
    }

    private void Update()
    {

    }

    public virtual void Attack()
    {
        // Default attack behavior
    }

    public virtual void Move()
    {

    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject, 0.25f);
    }

}
