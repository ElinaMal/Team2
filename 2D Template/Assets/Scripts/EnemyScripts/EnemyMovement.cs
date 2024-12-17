using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float lastDirectionChange;
    private float directionChangeTime;
    [SerializeField] private float enemyVelocity;
    private Vector2 movementDirection;
    private Vector2 movement;

    [SerializeField] private Animator anim;
    [SerializeField] private float changeTimeMin;
    [SerializeField] private float changeTimeMax;
    [SerializeField] private float waitTime;

    private bool wait = false;
    public bool FacingLeft = false;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        directionChangeTime = UnityEngine.Random.Range(changeTimeMin, changeTimeMax);
        lastDirectionChange = 0f;
        FindMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastDirectionChange > directionChangeTime)
        {
            StartCoroutine(StandingStill());
            lastDirectionChange = Time.time;
            directionChangeTime = UnityEngine.Random.Range(changeTimeMin, changeTimeMax);
            FindMovement();
        }

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (wait == false)
        {
            _rb.velocity = new Vector2(movement.x, movement.y);
            
            if (movement.x > 0 && FacingLeft == true)
            {
                FacingLeft = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (movement.x < 0 && FacingLeft == false)
            {
                FacingLeft = true;
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }

    void FindMovement()
    {
        movementDirection = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f,1.0f));
        movement = movementDirection * enemyVelocity;
    }

    IEnumerator StandingStill()
    {
        wait = true;
        anim.SetBool("isWalking", false);
        _rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(waitTime);
        wait = false;
    }
}
