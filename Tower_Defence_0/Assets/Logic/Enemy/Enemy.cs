using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    protected int health;
    protected int damage;

    protected float speedX;
    protected float speedY;

    protected Vector3 size = new Vector3(50, 50, 50);

    protected Collider enemyCollider;
    protected Rigidbody enemyRigidbody;
    protected Enemy()
    {
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (this.GetComponent<Rigidbody2D>() != null)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void Start()
    {
        this.spriteRenderer.size = size;
    }

    public virtual void Attack()
    {
        // Default attack behavior
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
        Destroy(this, 0.25f);
    }
}
