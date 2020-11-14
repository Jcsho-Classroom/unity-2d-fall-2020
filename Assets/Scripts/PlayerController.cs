using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    [Range(1, 100)]
    public int maxHealth = 5;
    public int currentHealth;
    public float damageCooldown = 3.0f;

    private Animator _animator;
    private Rigidbody2D _rb2d;
    private float _horizontal;
    private float _vertical;
    private float _timer;
    private bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // get input
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _animator.SetFloat("Look X", _horizontal);
        _animator.SetFloat("Look Y", _vertical);

        if (isInvincible == true)
        {
            _timer = _timer - Time.deltaTime;
            if (_timer < 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        Move(_horizontal, _vertical);
    }

    public void Move(float x, float y)
    {
        // move the player
        Vector2 velocity = new Vector2(x, y);
        _animator.SetFloat("Speed", Math.Abs(velocity.x + velocity.y));
        _rb2d.MovePosition(_rb2d.position + velocity * (speed * Time.fixedDeltaTime));
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible == true)
            {
                return;
            }
            isInvincible = true;
            _timer = damageCooldown;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
