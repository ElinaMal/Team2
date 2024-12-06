using System.Collections;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Rigidbody2D rigidBody;
    public EnemyDetection EnemyDetection;
    private Vector2 targetDirection;
    private bool facingLeft;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetDirection();
        MovementControl();
        Rotation();
    }

    private void UpdateTargetDirection()
    {
        if (EnemyDetection.detected && EnemyDetection.correctTarget)
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
        if (targetDirection.x > 0 && facingLeft == true)
        {
            facingLeft = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            /*
            GetComponent<SpriteRenderer>().flipX = false;
            */
        }
        else if (targetDirection.x < 0 && facingLeft == false)
        {
            facingLeft = true;
            transform.rotation = Quaternion.Euler(0, -180, 0);
            /*
            GetComponent<SpriteRenderer>().flipX = true;
            */
        }
    }

    private void MovementControl()
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
