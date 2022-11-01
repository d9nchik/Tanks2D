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
    public float rotatioinSpeed = 10f;

    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
        rb.velocity = transform.right * speed;
    }


  


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
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
