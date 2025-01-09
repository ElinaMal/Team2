using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    [SerializeField] public float maxSpeed = 15;
    bool facingLeft = false;
    public Animator anim;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left)) //check for the player HOLDING DOWN the left button
        {
            
            anim.SetBool("isMoving", true);

            _rb.velocity = new Vector2 (-maxSpeed, _rb.velocity.y);


            if (facingLeft == false)
            {
                facingLeft = true;
                transform.Rotate(0, 180, 0);
            }
        }

        if (Input.GetKey(right)) //check for the player HOLDING DOWN the right button
        {
            
            anim.SetBool("isMoving", true);
            
            _rb.velocity = new Vector2(maxSpeed, _rb.velocity.y);

            if (facingLeft == true)
            {
                facingLeft = false;
                transform.Rotate(0, 180, 0);
            }
        }

        if (Input.GetKey(up)) //check for the player HOLDING DOWN the up button
        {
            
            anim.SetBool("isMoving", true);
            
            _rb.velocity = new Vector2(_rb.velocity.x, maxSpeed);
        }

        if (Input.GetKey(down)) //check for the player HOLDING DOWN the down button
        {
            
            anim.SetBool("isMoving", true);
            
            _rb.velocity = new Vector2(_rb.velocity.x, -maxSpeed);
        }
        
        if (!Input.GetKey(up) && !Input.GetKey(down) && !Input.GetKey(left) && !Input.GetKey(right))
        {
            anim.SetBool("isMoving", false);
        }
    }
}
