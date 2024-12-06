using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float lastDirectionChange;
    [SerializeField] private float directionChangeTime;
    [SerializeField] private float enemyVelocity;
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private Vector2 movement;
    private bool wait = false;

    public bool FacingLeft = false;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        directionChangeTime = UnityEngine.Random.Range(5.0f, 10.0f);
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
            directionChangeTime = UnityEngine.Random.Range(5.0f, 10.0f);
            FindMovement();
        }

        if (wait == false)
        {
            _rb.velocity = new Vector2(movement.x, movement.y);

            if (movement.x > 0 && FacingLeft == true)
            {
                FacingLeft = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (movement.x < 0 && FacingLeft == false)
            {
                FacingLeft = true;
                GetComponent<SpriteRenderer>().flipX = true;
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
        _rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2.6f);
        wait = false;
    }
}
