using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    public void Start()
    {
        Debug.Log("Goblin Start");
        Sprite goblinSprite = Resources.Load<Sprite>("Sprites/Goblins/goblinsheet");
        this.spriteRenderer.sprite = goblinSprite;
    }

    public Goblin(int startingHealth, int startingDamage)
    {
        health = startingHealth;
        damage = startingDamage;

        speedX = 10;
    }

    protected override void Die()
    {
        base.Die();
    }

    public override void Attack()
    {
        // Goblin attack behavior
    }
}
