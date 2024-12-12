using UnityEngine;

public class UndeadChasePlayer : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Rigidbody2D rigidBody;
    public UndeadToPlayer undeadToPlayer;
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
        if (undeadToPlayer.detected && undeadToPlayer.correctTarget)
        {
            targetDirection = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, undeadToPlayer.target.position, Time.deltaTime * velocity);
            targetDirection = undeadToPlayer.directionToPlayer;
        }
    }

    private void Rotation()
    {
        if (targetDirection.x > 0 && facingLeft == true)
        {
            facingLeft = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (targetDirection.x < 0 && facingLeft == false)
        {
            facingLeft = true;
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    private void MovementControl()
    {
    }
}
