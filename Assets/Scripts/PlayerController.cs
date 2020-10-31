using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    
    private Rigidbody2D _rb2d;
    private float _horizontal;
    private float _vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Move(_horizontal, _vertical);
    }

    public void Move(float x, float y)
    {
        // move the player
        Vector2 velocity = new Vector2(x, y);
        _rb2d.MovePosition(_rb2d.position + velocity * (speed * Time.fixedDeltaTime));
    }
}
