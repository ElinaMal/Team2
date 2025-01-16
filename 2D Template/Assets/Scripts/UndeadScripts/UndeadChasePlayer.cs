 using UnityEngine;

public class UndeadChasePlayer : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Animator anim;
    public UndeadToPlayer undeadToPlayer;
    private Vector2 targetDirection;
    private bool facingLeft;

    // Update is called once per frame
    void Update()
    {
        UpdateTargetDirection();
        Rotation();
    }

    private void UpdateTargetDirection()
    {
        if (undeadToPlayer.detected && undeadToPlayer.correctTarget)
        {
            anim.SetBool("isWalking", false);
            targetDirection = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            anim.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, undeadToPlayer.target.position, Time.deltaTime * velocity);
            targetDirection = undeadToPlayer.directionToPlayer;
        }
    }

    private void Rotation()
    {
        if (undeadToPlayer.enabled)
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
    }
}
