using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    private int startingHealth = 3;
    private int startingDamage = 2;

    private float speedModifier = 1;

    public void Start()
    {
        Debug.Log("Orc Start");

        health = startingHealth;
        damage = startingDamage;

        speedX = 5;
        speedY = 5;

        Sprite orcSprite = Resources.Load<Sprite>("Sprites/Orcs/orcsheet");
        this.spriteRenderer.sprite = orcSprite;
    }

    private void Update()
    {
        if (health > 0)
        {
            Move();
        }
        else
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
        // Orc attack behavior
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
