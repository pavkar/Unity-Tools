using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    private int startingHealth = 5;
    private int startingDamage = 1;

    private float speedModifier = 1;

    public void Start()
    {
        Debug.Log("Goblin Start");

        health = startingHealth;
        damage = startingDamage;

        speedX = 10;
        speedY = 10;

        Sprite goblinSprite = Resources.Load<Sprite>("Sprites/Goblins/goblinsheet");
        this.spriteRenderer.sprite = goblinSprite;
    }

    private void Update()
    {
        if (health > 0)
        {
            Move();
        } else
        {
            Die();
        }
    }

    public override void Move()
    {
        Vector3 currentPosition = transform.position;

        float moveAmount = currentPosition.y - speedModifier * speedY * Time.deltaTime;

        Vector3 newPosition = new Vector3(currentPosition.x, moveAmount, currentPosition.z);

        transform.position = newPosition;
    }

    protected override void Die()
    {
        base.Die();
    }

    public override void Attack()
    {
        // Goblin attack behavior
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.gameObject.tag)
        {
            case "Wall":
                speedModifier = 0f;
                health = 0;
                break;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Water":
                speedModifier = 0.50f;
                break;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Water":
                speedModifier = 1f;
                break;
        }
    }
}
