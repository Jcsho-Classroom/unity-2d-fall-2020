using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public bool vertical;
    public float patrolTime = 3.0f;

    private Animator _animator;
    private Rigidbody2D _rb2d;
    private float _timer;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _timer = patrolTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timer = _timer - Time.deltaTime;

        if (_timer < 0)
        {
            direction = -direction;
            _timer = patrolTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = _rb2d.position;

        if (vertical == true)
        {
            _animator.SetFloat("MoveX", 0);
            _animator.SetFloat("MoveY", direction);
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            _animator.SetFloat("MoveY", 0);
            _animator.SetFloat("MoveX", direction);
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        _rb2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
