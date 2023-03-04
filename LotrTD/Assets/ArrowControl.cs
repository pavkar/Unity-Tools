using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;

    private float lifeTimeStart = 0f;
    private const float maxLifeTime = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        lifeTimeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.position * Time.deltaTime * speed;
        //transform.Translate(Speed * Time.deltaTime * 1, 0, 0f);
        if (lifeTimeStart + maxLifeTime < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Arrow Collision");
        if (collision.gameObject.GetComponent<Wall>())
            return;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Arrow trigger");
        if (collision.gameObject.GetComponent<Wall>())
            return;
        Destroy(gameObject);
    }
}
