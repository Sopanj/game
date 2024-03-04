using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    int bulletDir;
    Rigidbody2D rb;

    void Start()
    {
        bulletDir = movement.Direction;
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile", lifeTime);
    }

    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.5f);
        if (col == null)
        {
            if (col.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                col.gameObject.SetActive(false);
            }
            DestroyProjectile();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletDir * speed;
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}
