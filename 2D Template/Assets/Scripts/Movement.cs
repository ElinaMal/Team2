using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    public float speed = 8;

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
            //get the GameObject's Rigidbody2D component and set its velocity to be to the left at the given speed
            _rb.velocity = new Vector2(-1,0) * speed;
        }

        if (Input.GetKey(right)) //check for the player HOLDING DOWN the right button
        {
            //get the GameObject's Rigidbody2D component and set its velocity to be to the right at the given speed
            _rb.velocity = new Vector2(1,0) * speed;
        }

        if (Input.GetKey(up)) //check for the player HOLDING DOWN the up button
        {
            //get the GameObject's Rigidbody2D component and set its velocity to be up at the given speed
            _rb.velocity = new Vector2(0,1) * speed;
        }

        if (Input.GetKey(down)) //check for the player HOLDING DOWN the down button
        {
            //get the GameObject's Rigidbody2D component and set its velocity to be down at the given speed
            _rb.velocity = new Vector2(0,-1) * speed;
        }
    }
}
