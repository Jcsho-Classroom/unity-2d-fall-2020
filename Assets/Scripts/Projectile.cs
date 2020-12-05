using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D _rb2d;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.magnitude > 1000f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        _rb2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemy = collision.collider.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.Fix();
        }

        Destroy(gameObject);
    }
}
