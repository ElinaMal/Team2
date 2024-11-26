using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float lastDirectionChange;
    [SerializeField] private float directionChangeTime;
    [SerializeField] private float enemyVelocity;
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float maxSpeed = 15;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        directionChangeTime = UnityEngine.Random.Range(1.0f, 5.0f);
        lastDirectionChange = 0f;
        FindMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastDirectionChange > directionChangeTime)
        {
            lastDirectionChange = Time.time;
            directionChangeTime = UnityEngine.Random.Range(1.0f, 5.0f);
            FindMovement();
        }

        if (_rb.velocity.x < -maxSpeed)
        {
            _rb.velocity = new Vector2(-maxSpeed, _rb.velocity.y);
        }

        if (_rb.velocity.x > maxSpeed)
        {
            _rb.velocity = new Vector2(maxSpeed, _rb.velocity.y);
        }

        if (_rb.velocity.y < -maxSpeed)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -maxSpeed);
        }

        if (_rb.velocity.x > maxSpeed)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, maxSpeed);
        }

        _rb.AddForce(new Vector2(movement.x, movement.y));
    }

    void FindMovement()
    {
        movementDirection = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f,1.0f));
        movement = movementDirection * enemyVelocity;
    }
}