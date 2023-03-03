using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    public void Start()
    {
        Sprite orcSprite = Resources.Load<Sprite>("Sprites/Orcs/orcsheet");
        this.spriteRenderer.sprite = orcSprite;
    }
    public Orc(int startingHealth, int startingDamage)
    {
        health = startingHealth;
        damage = startingDamage;

        speedX = 5;
    }

    protected override void Die()
    {
        base.Die();
    }

    public override void Attack()
    {
        // Orc attack behavior
    }
}
