using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Rigidbody2D rigidBody;
    public EnemyDetection EnemyDetection;
    private Vector2 targetDirection;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetDirection();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (EnemyDetection.detected)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyDetection.target.position, Time.deltaTime * velocity);
            targetDirection = EnemyDetection.directionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void Rotation()
    {
        
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            
            GetComponent<EnemyMovement>().enabled = true;
            
        }
        else
        {
            
            GetComponent<EnemyMovement>().enabled = false;
            
            
        }
    }
}
