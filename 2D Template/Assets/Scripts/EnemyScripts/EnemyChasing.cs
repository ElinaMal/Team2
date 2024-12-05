using System.Collections;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Rigidbody2D rigidBody;
    public EnemyDetection EnemyDetection;
    private Vector2 targetDirection;
    public EnemyMovement enemyMovement;
    private bool facingLeft;
    private bool ran = false;

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
        if (EnemyDetection.directionToPlayer.x > 0 && facingLeft == true)
        {
            facingLeft = false;
            transform.Rotate(0, 180, 0);
        }
        else if (EnemyDetection.directionToPlayer.x < 0 && facingLeft == false)
        {
            facingLeft = true;
            transform.Rotate(0, 180, 0);
        }
    }

    private void MovementControl()
    {
        if (targetDirection == Vector2.zero)
        {
            GetComponent<EnemyMovement>().enabled = true;
            ran = false;
        }
        else
        {
            
            if (ran == false)
            {
                facingLeft = enemyMovement.FacingLeft;
            }

            ran = true;
            GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
