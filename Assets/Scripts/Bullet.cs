using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 20;
    [SerializeField]
    private int damage = 10;
    private string owner = "";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (owner == "")
        {
            owner = collision.tag;
        }
        if (!collision.CompareTag(owner))
        {
            Destroy(gameObject);
            Tank tank = collision.GetComponent<Tank>();
            if (tank != null)
            {
                tank.TakeDamage(damage);
            }
        }
    }
}
