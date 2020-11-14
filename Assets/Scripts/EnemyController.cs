using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public bool vertical;
    public float patrolTime = 3.0f;

    private Rigidbody2D _rb2d;
    private float _timer;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
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
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        _rb2d.MovePosition(position);
    }
}
