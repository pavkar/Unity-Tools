using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collision");

        ArrowControl arrow = collision.gameObject.GetComponent<ArrowControl>();

        if (arrow != null)
        {
            this.health -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy trigger");
        ArrowControl arrow = collision.gameObject.GetComponent<ArrowControl>();

        if (arrow != null)
        {
            Debug.Log(" with arrow");
            this.health -= 1;
        }
    }
}
