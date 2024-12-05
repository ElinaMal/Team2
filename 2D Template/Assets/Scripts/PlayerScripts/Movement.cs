using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    public float speed = 8, maxSpeed = 15;
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
            

            if (_rb.velocity.x < -maxSpeed) //sets a limit for speed
            {
                _rb.velocity = new Vector2(-maxSpeed, _rb.velocity.y);
            }

            //get the GameObject's Rigidbody2D component and set its velocity to be to the left at the given speed
            _rb.AddForce(new Vector2(-1, 0) * speed);

            if (facingLeft == false)
            {
                facingLeft = true;
                transform.Rotate(0, 180, 0);
            }
        }

        if (Input.GetKey(right)) //check for the player HOLDING DOWN the right button
        {
            
            anim.SetBool("isMoving", true);
            

            if (_rb.velocity.x > maxSpeed) //sets a limit for speed
            {
                _rb.velocity = new Vector2(maxSpeed, _rb.velocity.y);
            }

            //get the GameObject's Rigidbody2D component and set its velocity to be to the right at the given speed
            _rb.AddForce(new Vector2(1, 0) * speed);

            if (facingLeft == true)
            {
                facingLeft = false;
                transform.Rotate(0, 180, 0);
            }
        }

        if (Input.GetKey(up)) //check for the player HOLDING DOWN the up button
        {
            
            anim.SetBool("isMoving", true);
            

            if (_rb.velocity.y > maxSpeed) //sets a limit for speed
            {
                _rb.velocity = new Vector2(_rb.velocity.x, maxSpeed);
            }

            //get the GameObject's Rigidbody2D component and set its velocity to be up at the given speed
            _rb.AddForce(new Vector2(0, 1) * speed);
        }

        if (Input.GetKey(down)) //check for the player HOLDING DOWN the down button
        {
            
            anim.SetBool("isMoving", true);
            

            if (_rb.velocity.y < -maxSpeed) //sets a limit for speed
            {
                _rb.velocity = new Vector2(_rb.velocity.x, -maxSpeed);
            }

            //get the GameObject's Rigidbody2D component and set its velocity to be down at the given speed
            _rb.AddForce(new Vector2(0, -1) * speed);
        }
        
        if (Input.GetKeyUp(left))
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetKeyUp(right))
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetKeyUp(up))
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetKeyUp(down))
        {
            anim.SetBool("isMoving", false);
        }
        
    }
}
